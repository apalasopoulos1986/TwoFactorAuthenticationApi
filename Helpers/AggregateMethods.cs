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
            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
            IEnumerable<Contact> contacts = _contactService.GetAllContacts();
            foreach (var contact in contacts)
            {
                if (contact.WorkPhone!=null)
                {
                    //phoneNumbers.Add(contact.WorkPhone);
                }

            }

        }
    }
}
