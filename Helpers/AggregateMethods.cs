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
       

        public AggregateMethods(
            IContactService contactService
            )
        {
            _contactService = contactService;
           

        }
        public void FillMethodWithCriteria()
        {
            List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
            IEnumerable<Contact> contacts = _contactService.GetAllContacts();
            foreach (var contact in contacts)
            {
                if (contact.WorkPhone!=null)
                {

                }

            }

        }
    }
}
