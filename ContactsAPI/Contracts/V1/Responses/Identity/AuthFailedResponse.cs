﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Contracts.V1.Responses.Identity
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
