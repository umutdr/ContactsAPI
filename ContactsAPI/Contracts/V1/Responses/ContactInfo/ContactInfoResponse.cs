using ContactsAPI.Models;
using System;

namespace ContactsAPI.Contracts.V1.Responses.ContactInfo
{
    public class ContactInfoResponse
    {
        public Guid Id { get; set; }

        public Guid ContactId { get; set; }

        public ContactInfoType Type { get; set; }

        public string Content { get; set; }
    }
}
