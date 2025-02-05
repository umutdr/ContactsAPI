﻿using ContactsAPI.Domain;
using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsAPI.Services.ContactInfoServices
{
    public interface IContactInfoService
    {
        Task<ContactInfo> GetAsync(Guid contactInfoId);

        Task<List<ContactInfo>> GetAllAsync();

        Task<List<ContactInfo>> GetAllByContactAsync(Guid contactId);

        Task<List<ContactInfo>> GetAllByContactAsync(Guid contactId, ContactInfoType type);

        Task<bool> CreateAsync(ContactInfo contactInfo);

        Task<bool> UpdateAsync(ContactInfo contactInfo);

        Task<bool> DeleteAsync(Guid contactInfoId);

        Task<bool> CheckUserForOwnership(Guid contactId, string userId);

        Task<List<Report>> GetReport();
    }
}
