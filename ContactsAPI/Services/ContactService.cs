using ContactsAPI.Data;
using ContactsAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly DataContext _dataContext;

        public ContactService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Contact> GetAsync(Guid contactId)
        {
            return await _dataContext.Contacts.SingleOrDefaultAsync(x => x.Id == contactId);
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _dataContext.Contacts.ToListAsync();
        }

        public async Task<bool> CreateAsync(Contact contact)
        {
            await _dataContext.Contacts.AddAsync(contact);

            bool saved = await _dataContext.SaveChangesAsync() > 0;

            return saved;
        }

        public async Task<bool> UpdateAsync(Contact contactToUpdate)
        {
            _dataContext.Contacts.Update(contactToUpdate);

            bool saved = await _dataContext.SaveChangesAsync() > 0;

            return saved;
        }

        public async Task<bool> DeleteAsync(Guid contactIdToDelete)
        {
            var contact = await GetAsync(contactIdToDelete);

            _dataContext.Contacts.Remove(contact);

            bool saved = await _dataContext.SaveChangesAsync() > 0;

            return saved;
        }

    }
}
