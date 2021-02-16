using ContactsAPI.Contracts;
using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests;
using ContactsAPI.Contracts.V1.Responses;
using ContactsAPI.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Controllers.V1
{
    public class ContactController : Controller
    {
        private List<Contact> _contacts;

        public ContactController()
        {
            _contacts = new List<Contact>();

            for (var i = 0; i < 5; i++)
            {
                _contacts.Add(new Contact()
                {
                    Id = Guid.NewGuid().ToString()
                });
            }
        }

        [HttpGet(APIRoutes.ContactControllerRoutes.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_contacts);
        }

        [HttpPost(APIRoutes.ContactControllerRoutes.Create)]
        public IActionResult Create([FromBody] CreateContactRequest contactRequest)
        {
            if (string.IsNullOrWhiteSpace(contactRequest.Id))
                contactRequest.Id = Guid.NewGuid().ToString();

            var contact = new Contact
            {
                Id = contactRequest.Id
            };

            _contacts.Add(contact);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var createdLocationUri = $"{baseUrl}/{APIRoutes.ContactControllerRoutes.Get.Replace("{contactId}", contactRequest.Id)}";

            var contactResponse = new ContactResponse
            {
                Id = contact.Id
            };

            return Created(createdLocationUri, contactResponse);
        }
    }
}
