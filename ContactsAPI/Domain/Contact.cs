﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Domain
{
    public class Contact
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
    }
}
