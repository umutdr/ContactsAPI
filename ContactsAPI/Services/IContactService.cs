using ContactsAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllAsync();

        Task<Contact> GetAsync(Guid contactId);

        Task<bool> CreateAsync(Contact contact);

        Task<bool> UpdateAsync(Contact contact);

        Task<bool> DeleteAsync(Guid contactIdToDelete);
    }
}
