using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoFactorAuthenticationApi.Entities
{
    public class PhoneNumber
    {
        public Guid Id { get; set; }

        public string ValueOfNumber { get; set; }
    }
}
