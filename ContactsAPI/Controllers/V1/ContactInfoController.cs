using ContactsAPI.Cache;
using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests.ContactInfo;
using ContactsAPI.Contracts.V1.Responses.ContactInfo;
using ContactsAPI.Domain;
using ContactsAPI.Extensions;
using ContactsAPI.Models;
using ContactsAPI.Services;
using ContactsAPI.Services.ContactInfoServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ContactsAPI.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ContactInfoController : Controller
    {
        private readonly IContactInfoService _contactInfoService;

        public ContactInfoController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet(APIRoutes.ContactInfoControllerRoutes.Get)]
        [Cached(60 * 10)]
        public async Task<IActionResult> Get([FromRoute] Guid contactInfoId)
        {
            var contactInfo = await _contactInfoService.GetAsync(contactInfoId);

            if (contactInfo == null)
                return NotFound();

            return Ok(contactInfo);
        }

        [HttpGet(APIRoutes.ContactInfoControllerRoutes.GetAll)]
        [Cached(60 * 10)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _contactInfoService.GetAllAsync());
        }

        [HttpGet(APIRoutes.ContactInfoControllerRoutes.GetAllByContact)]
        [Cached(60 * 10)]
        public async Task<IActionResult> GetAllByContact([FromRoute] Guid contactId)
        {
            return Ok(await _contactInfoService.GetAllByContactAsync(contactId));
        }

        [HttpGet(APIRoutes.ContactInfoControllerRoutes.GetAllByContactAndType)]
        [Cached(60 * 10)]
        public async Task<IActionResult> GetAllByContactAndType([FromRoute] Guid contactId, ContactInfoType type)
        {
            return Ok(await _contactInfoService.GetAllByContactAsync(contactId, type));
        }

        [HttpPost(APIRoutes.ContactInfoControllerRoutes.Create)]
        public async Task<IActionResult> Create([FromBody] CreateContactInfoRequest contactInfoRequest)
        {
            var contactInfo = new ContactInfo
            {
                ContactId = contactInfoRequest.ContactId,
                Content = contactInfoRequest.Content,
                Type = contactInfoRequest.Type,
            };

            await _contactInfoService.CreateAsync(contactInfo);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var getLocation = $"{baseUrl}/{APIRoutes.ContactInfoControllerRoutes.Get.Replace("{contactInfoId}", contactInfo.Id.ToString())}";

            var contactInfoResponse = new ContactInfoResponse
            {
                Id = contactInfo.Id,
                ContactId = contactInfo.ContactId,
                Content = contactInfo.Content,
                Type = contactInfo.Type,
            };

            return Created(getLocation, contactInfoResponse);
        }

        [HttpPut(APIRoutes.ContactInfoControllerRoutes.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid contactInfoId, [FromBody] UpdateContactInfoRequest contactInfoRequest)
        {
            var isOwner = await _contactInfoService.CheckUserForOwnership(contactInfoId, HttpContext.GetCurrentUserId());

            if (!isOwner)
                return BadRequest(new { error = "You are not the owner of this contact info" });

            var updatedContactInfo = new ContactInfo
            {
                Id = contactInfoId,
                Content = contactInfoRequest.Content,
                Type = contactInfoRequest.Type
            };

            var updated = await _contactInfoService.UpdateAsync(updatedContactInfo);

            if (updated)
                return Ok(updatedContactInfo);

            return NotFound();
        }

        [HttpDelete(APIRoutes.ContactInfoControllerRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid contactInfoId)
        {
            var isOwner = await _contactInfoService.CheckUserForOwnership(contactInfoId, HttpContext.GetCurrentUserId());

            if (!isOwner)
                return BadRequest(new { error = "You are not the owner of this contact info" });

            var deleted = await _contactInfoService.DeleteAsync(contactInfoId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        //[AllowAnonymous]
        [Cached(60*10)]
        [HttpGet(APIRoutes.ContactInfoControllerRoutes.GetReport)]
        public async Task<IActionResult> GetReport()
        {
            return Ok(await _contactInfoService.GetReport());
        }

    }
}
