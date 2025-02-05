﻿using ContactsAPI.Cache;
using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests.Contact;
using ContactsAPI.Contracts.V1.Responses.Contact;
using ContactsAPI.Domain;
using ContactsAPI.Extensions;
using ContactsAPI.Services;
using ContactsAPI.Services.ContactServices;
using ContactsAPI.Services.RedisCacheServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ContactsAPI.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IRedisCacheService _redisCacheService;

        public ContactController(IContactService contactService, IRedisCacheService redisCacheService)
        {
            _contactService = contactService;
            _redisCacheService = redisCacheService;
        }

        [HttpGet(APIRoutes.ContactControllerRoutes.Get)]
        [Cached(60 * 10)]
        public async Task<IActionResult> Get([FromRoute] Guid contactId)
        {
            var contact = await _contactService.GetAsync(contactId);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpGet(APIRoutes.ContactControllerRoutes.GetAll)]
        [Cached(60 * 10)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contactService.GetAllAsync());
        }

        [HttpPost(APIRoutes.ContactControllerRoutes.Create)]
        public async Task<IActionResult> Create([FromBody] CreateContactRequest contactRequest)
        {
            var contact = new Contact
            {
                FirstName = contactRequest.FirstName,
                LastName = contactRequest.LastName,
                CompanyName = contactRequest.CompanyName,
                OwnerUserId = HttpContext.GetCurrentUserId(),
            };

            await _contactService.CreateAsync(contact);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var createdLocationUri = $"{baseUrl}/{APIRoutes.ContactControllerRoutes.Get.Replace("{contactId}", contact.Id.ToString())}";

            var contactResponse = new ContactResponse
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                CompanyName = contact.CompanyName,
            };

            await _redisCacheService
                .DeleteCachedResponseAsync(
                    new string[]
                    {
                            HttpContext.Request.Path,
                            APIRoutes.ContactControllerRoutes.GetAll
                    });
            return Created(createdLocationUri, contactResponse);
        }

        [HttpPut(APIRoutes.ContactControllerRoutes.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid contactId, [FromBody] UpdateContactRequest contactRequest)
        {
            var isOwner = await _contactService.CheckUserForOwnership(contactId, HttpContext.GetCurrentUserId());

            if (!isOwner)
                return BadRequest(new { error = "You are not the owner of this contact" });

            var contact = await _contactService.GetAsync(contactId);
            contact.FirstName = contactRequest.FirstName;
            contact.LastName = contactRequest.LastName;
            contact.CompanyName = contactRequest.CompanyName;

            var updated = await _contactService.UpdateAsync(contact);

            if (updated)
            {
                await _redisCacheService
                    .DeleteCachedResponseAsync(
                        new string[]
                        {
                            HttpContext.Request.Path,
                            APIRoutes.ContactControllerRoutes.GetAll
                        });

                return Ok(contact);
            }

            return NotFound();
        }

        [HttpDelete(APIRoutes.ContactControllerRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid contactId)
        {
            var isOwner = await _contactService.CheckUserForOwnership(contactId, HttpContext.GetCurrentUserId());

            if (!isOwner)
                return BadRequest(new { error = "You are not the owner of this contact" });

            var deleted = await _contactService.DeleteAsync(contactId);

            if (deleted)
            {
                await _redisCacheService
                    .DeleteCachedResponseAsync(
                        new string[]
                        {
                            HttpContext.Request.Path,
                            APIRoutes.ContactControllerRoutes.GetAll
                        });
                return NoContent();
            }

            return NotFound();
        }
    }
}
