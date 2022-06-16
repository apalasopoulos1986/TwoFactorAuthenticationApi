using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoFactorAuthenticationApi.Entities;
using TwoFactorAuthenticationApi.Services;

namespace TwoFactorAuthenticationApi.Helpers
{
    public class AggregateMethods
    {
        private IContactService _contactService;
        private IPhoneNumberService _phoneNumberService;

        public AggregateMethods
            (
            IContactService contactService,
            IPhoneNumberService phoneNumberService
            )
        {
            _contactService = contactService;

            _phoneNumberService = phoneNumberService;
        }
        public void FillPhoneNumberValuesWithCriteria()
        {
            try
            {
                IEnumerable<Contact> contacts = _contactService.GetAllContacts();
                foreach (var contact in contacts)
                {
                    if (contact.WorkPhone != null)
                    {
                        var newPhoneNumber = new PhoneNumber();
                        newPhoneNumber.Id= Guid.NewGuid();
                        newPhoneNumber.ValueOfNumber = contact.WorkPhone;
                        _phoneNumberService.AddPhoneNumber(newPhoneNumber);

                        if (_phoneNumberService.SaveAll())
                        {
                          
                        }

                    }

                }

            }
            catch (Exception ex)
            {

               
            }
           // List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
           

        }
    }
}
