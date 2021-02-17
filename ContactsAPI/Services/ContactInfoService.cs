using ContactsAPI.Data;
using ContactsAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Services
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly DataContext _dataContext;

        public ContactInfoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ContactInfo> GetAsync(Guid contactInfoId)
        {
            return await _dataContext.ContactInfos.SingleOrDefaultAsync(x => x.Id == contactInfoId);
        }

        public async Task<List<ContactInfo>> GetAllAsync()
        {
            return await _dataContext.ContactInfos.ToListAsync();
        }

        public async Task<bool> CreateAsync(ContactInfo contactInfo)
        {
            await _dataContext.ContactInfos.AddAsync(contactInfo);

            bool saved = await _dataContext.SaveChangesAsync() > 0;

            return saved;
        }

        public async Task<bool> UpdateAsync(ContactInfo contactInfoToUpdate)
        {
            _dataContext.ContactInfos.Update(contactInfoToUpdate);

            bool saved = await _dataContext.SaveChangesAsync() > 0;

            return saved;
        }

        public async Task<bool> DeleteAsync(Guid contactInfoIdToDelete)
        {
            var contactInfo = await GetAsync(contactInfoIdToDelete);

            _dataContext.ContactInfos.Remove(contactInfo);

            bool saved = await _dataContext.SaveChangesAsync() > 0;

            return saved;
        }

    }
}
