﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwoFactorAuthenticationApi.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }


        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }
    }
}
