using System;

namespace ContactsAPI.Contracts.V1.Responses.Contact
{
    public class ContactResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

    }
}
