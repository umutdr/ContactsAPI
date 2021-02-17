using ContactsAPI.Domain;
using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Contracts.V1.Requests.ContactInfo
{
    public class CreateContactInfoRequest
    {
        public Guid ContactId { get; set; }

        public ContactInfoType Type { get; set; }

        public string Content { get; set; }
    }
}
