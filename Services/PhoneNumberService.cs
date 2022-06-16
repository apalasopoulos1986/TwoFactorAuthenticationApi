using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwoFactorAuthenticationApi.Entities;
using TwoFactorAuthenticationApi.Helpers;

namespace TwoFactorAuthenticationApi.Services
{
    public interface IPhoneNumberService
    {
        IEnumerable<PhoneNumber> GetAllPhoneNumbers();
        void AddPhoneNumber(PhoneNumber phoneNumber);
        bool SaveAll();
        PhoneNumber GetPhoneNumberById(Guid id);
        void DeletePhoneNumberById(Guid id);

    }
    public class PhoneNumberService: IPhoneNumberService
    {
     
        private readonly DataContext _dataContext;

        public PhoneNumberService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Seed()
        {
            _dataContext.Database.EnsureCreated();
        }

        public void AddPhoneNumber (PhoneNumber phoneNumber)
        {
            _dataContext.Add(phoneNumber);
        }

        public void DeletePhoneNumberById(Guid id)
        {
            var phoneNumber = _dataContext.PhoneNumbers.FirstOrDefault(c => c.Id == id);

            if (phoneNumber != null)
            {
                _dataContext.PhoneNumbers.Remove(phoneNumber);
            }

        }

        public IEnumerable<PhoneNumber> GetAllPhoneNumbers()
        {
            try
            {
                return _dataContext.PhoneNumbers.ToList();
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public PhoneNumber GetPhoneNumberById(Guid id)
        {
            return _dataContext.PhoneNumbers.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveAll()
        {
            return _dataContext.SaveChanges() > 0;
        }

    }
}
