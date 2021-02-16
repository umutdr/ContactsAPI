using ContactsAPI.Contracts;
using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests;
using ContactsAPI.Contracts.V1.Responses;
using ContactsAPI.Domain;
using ContactsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Controllers.V1
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet(APIRoutes.ContactControllerRoutes.Get)]
        public IActionResult Get([FromRoute] Guid contactId)
        {
            var contact = _contactService.Get(contactId);

            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        [HttpGet(APIRoutes.ContactControllerRoutes.GetAll)]
        public IActionResult GetAll()
        {
            var contacts = _contactService.GetAll();

            return Ok(contacts);
        }

        [HttpPost(APIRoutes.ContactControllerRoutes.Create)]
        public IActionResult Create([FromBody] CreateContactRequest contactRequest)
        {
            var contact = new Contact
            {
                Id = (contactRequest.Id != Guid.Empty ? contactRequest.Id : Guid.NewGuid())
            };

            _contactService.GetAll().Add(contact);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var createdLocationUri = $"{baseUrl}/{APIRoutes.ContactControllerRoutes.Get.Replace("{contactId}", contactRequest.Id.ToString())}";

            var contactResponse = new ContactResponse
            {
                Id = contact.Id
            };

            return Created(createdLocationUri, contactResponse);
        }
    }
}
