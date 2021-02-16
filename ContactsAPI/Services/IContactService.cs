using ContactsAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Services
{
    public interface IContactService
    {
        List<Contact> GetAll();

        Contact Get(Guid contactId);

        bool Update(Contact contact);

        bool Delete(Guid contactIdToDelete);
    }
}
