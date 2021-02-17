using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests.Contact;
using ContactsAPI.Contracts.V1.Responses.Contact;
using ContactsAPI.Domain;
using ContactsAPI.Services;
using ContactsAPI.Services.ContactServices;
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

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet(APIRoutes.ContactControllerRoutes.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid contactId)
        {
            var contact = await _contactService.GetAsync(contactId);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpGet(APIRoutes.ContactControllerRoutes.GetAll)]
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

            return Created(createdLocationUri, contactResponse);
        }

        [HttpPut(APIRoutes.ContactControllerRoutes.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid contactId, [FromBody] UpdateContactRequest contactRequest)
        {
            var contact = new Contact
            {
                Id = contactId,
                FirstName = contactRequest.FirstName,
                LastName = contactRequest.LastName,
                CompanyName = contactRequest.CompanyName,
            };

            var updated = await _contactService.UpdateAsync(contact);

            if (updated)
                return Ok(contact);

            return NotFound();
        }

        [HttpDelete(APIRoutes.ContactControllerRoutes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid contactId)
        {
            var deleted = await _contactService.DeleteAsync(contactId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

    }
}
