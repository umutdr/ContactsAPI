using ContactsAPI.Data;
using ContactsAPI.Domain;
using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Services.ContactInfoServices
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

        public async Task<List<ContactInfo>> GetAllByContactAsync(Guid contactId)
        {
            return await _dataContext.ContactInfos.Where(x => x.ContactId == contactId).ToListAsync();
        }

        public async Task<List<ContactInfo>> GetAllByContactAsync(Guid contactId, ContactInfoType type)
        {
            return await _dataContext.ContactInfos
                    .Where(x =>
                            x.ContactId == contactId &&
                            x.Type == type)
                    .ToListAsync();
        }

        public async Task<bool> CreateAsync(ContactInfo contactInfo)
        {
            await _dataContext.ContactInfos.AddAsync(contactInfo);

            bool saved = await _dataContext.SaveChangesAsync() > 0;

            return saved;
        }

        public async Task<bool> UpdateAsync(ContactInfo contactInfoToUpdate)
        {
            var contactInfo = await GetAsync(contactInfoToUpdate.Id);

            if (contactInfo == null)
                return false;

            contactInfo.Content = contactInfoToUpdate.Content;
            contactInfo.Type = contactInfoToUpdate.Type;

            _dataContext.ContactInfos.Update(contactInfo);

            bool saved = await _dataContext.SaveChangesAsync() > 0;

            return saved;
        }

        public async Task<bool> DeleteAsync(Guid contactInfoIdToDelete)
        {
            var contactInfo = await GetAsync(contactInfoIdToDelete);

            if (contactInfo == null)
                return false;

            _dataContext.ContactInfos.Remove(contactInfo);

            bool saved = await _dataContext.SaveChangesAsync() > 0;

            return saved;
        }

        public async Task<bool> CheckUserForOwnership(Guid contactInfoId, string userId)
        {
            var contact =
                await _dataContext.ContactInfos
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x =>
                        x.Id == contactInfoId &&
                        x.Contact.OwnerUserId == userId);

            if (contact == null)
                return false;

            return true;
        }

    }
}
