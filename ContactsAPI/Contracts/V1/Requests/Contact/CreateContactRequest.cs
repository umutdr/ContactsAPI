using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Contracts.V1.Requests.Contact
{
    public class CreateContactRequest
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
    }
}
