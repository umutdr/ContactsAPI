using ContactsAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Services
{
    public interface IContactInfoService
    {
        Task<List<ContactInfo>> GetAllAsync();

        Task<ContactInfo> GetAsync(Guid contactInfoId);

        Task<bool> CreateAsync(ContactInfo contactInfo);

        Task<bool> UpdateAsync(ContactInfo contactInfo);

        Task<bool> DeleteAsync(Guid contactInfoId);
    }
}
