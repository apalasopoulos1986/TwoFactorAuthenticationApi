using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoFactorAuthenticationApi.DTOs;
using TwoFactorAuthenticationApi.Entities;
using TwoFactorAuthenticationApi.Helpers;

namespace TwoFactorAuthenticationApi.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        void AddContact(Contact contact);
        bool SaveAll();
        Contact GetContactById(Guid id);
        void DeleteContactById(Guid id);

    }
    public class ContactService
    {
        private readonly DataContext _dataContext;

        public ContactService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddContact(Contact contact)
        {
            _dataContext.Add(contact);
            
        }
        
        public void DeleteContactById(Guid id)
        {
            var contact=_dataContext.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                _dataContext.Contacts.Remove(contact);
            }

        }
        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                return _dataContext.Contacts.ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public Contact GetContactById(Guid id)
        {
            return _dataContext.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveAll()
        {
            return _dataContext.SaveChanges() > 0;
        }



    }
}
