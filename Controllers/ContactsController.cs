using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using TwoFactorAuthenticationApi.Authorization;
using TwoFactorAuthenticationApi.DTOs;
using TwoFactorAuthenticationApi.Entities;
using TwoFactorAuthenticationApi.Helpers;
using TwoFactorAuthenticationApi.Services;

namespace TwoFactorAuthenticationApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IContactService _contactService;
        private IPhoneNumberService _phoneNumberService;
        private readonly AppSettings _appSettings;

        public ContactsController(
            IContactService contactService,
            IPhoneNumberService phoneNumberService,
            IOptions<AppSettings> appSettings)
        {
            _contactService = contactService;
            _phoneNumberService = phoneNumberService;
            _appSettings = appSettings.Value;

        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            try
            {
                var results = _contactService.GetAllContacts();
                if (results != null)
                {
                    return Ok(results);
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Failed to get contacts: {ex}");
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Post([FromBody] ContactCreationRequestDTO contactCreationRequestDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newContact = new Contact();
                    newContact.Id = Guid.NewGuid();
                    newContact.Name = contactCreationRequestDTO.Name;
                    newContact.Surname = contactCreationRequestDTO.Surname;
                    newContact.Email = contactCreationRequestDTO.Email;
                    newContact.Address = contactCreationRequestDTO.Address;
                    newContact.HomePhone = contactCreationRequestDTO.HomePhone;
                    newContact.MobilePhone = contactCreationRequestDTO.MobilePhone;
                    newContact.WorkPhone = contactCreationRequestDTO.WorkPhone;
                    _contactService.AddContact(newContact);
                    if (_contactService.SaveAll())
                    {
                        var newPhoneNumber = new PhoneNumber();
                        if (newContact.WorkPhone != null)
                        {
                            newPhoneNumber.Id = Guid.NewGuid();
                            newPhoneNumber.ValueOfNumber = newContact.WorkPhone;
                            _phoneNumberService.AddPhoneNumber(newPhoneNumber);
                        }

                        if (_phoneNumberService.SaveAll())
                        {
                           
                        }
                        else
                        {
                            return BadRequest($"Failed to create new phoneNumber");
                        }
                        return Created($"contacts/{newContact.Id}", newContact);

                    } 

                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Failed to create new contact: {ex}");
            }
            return BadRequest("Failed to create new contact");
        }
        [HttpDelete("{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var contact = _contactService.GetContactById(id);
                if (contact == null)
                {
                    return BadRequest("Failed to delete contact");
                }
                _contactService.DeleteContactById(id);
                if (_contactService.SaveAll())
                {
                    return NoContent();
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Failed to delete contact: {ex}");
            }
            return BadRequest($"Failed to delete contact");
        }
        [HttpPut("{id:guid}")]
        public ActionResult Put(Guid id, [FromBody] ContactUpdateRequestDTO  contactUpdateRequestDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    var oldContact = _contactService.GetContactById(id);
                    if (oldContact == null)
                    {
                        return BadRequest("There is no contact to update");
                    }

                    oldContact.Name = contactUpdateRequestDTO.Name;
                    oldContact.Surname = contactUpdateRequestDTO.Surname;
                    oldContact.Email = contactUpdateRequestDTO.Email;
                    oldContact.Address = contactUpdateRequestDTO.Address;
                    oldContact.HomePhone = contactUpdateRequestDTO.HomePhone;
                    oldContact.MobilePhone = contactUpdateRequestDTO.MobilePhone;
                    oldContact.WorkPhone = contactUpdateRequestDTO.WorkPhone;

                    if (_contactService.SaveAll())
                    {
                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update contact: {ex}");

            }
            return BadRequest("Failed to update contact");
        }

    }


}

