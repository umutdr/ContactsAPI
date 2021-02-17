using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Contracts.V1.Requests.Identity
{
    public class UserLoginRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
