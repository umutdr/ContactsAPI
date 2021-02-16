using ContactsAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts;

        public ContactService()
        {
            _contacts = new List<Contact>();

            for (var i = 1; i <= 5; i++)
            {
                _contacts.Add(new Contact()
                {
                    Id = Guid.NewGuid(),
                    FirstName = $"FirstName {i}"
                });
            }
        }

        public Contact Get(Guid contactId)
        {
            var contact = _contacts.SingleOrDefault(x => x.Id == contactId);

            return contact;
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }
    }
}
