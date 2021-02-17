using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Contracts.V1
{
    public static class APIRoutes
    {
        private const string Root = "api";
        private const string Version = "/v1";
        private const string Base = Root + Version;

        private const string ContactControllerBase = Base + "/contacts";
        private const string ContactIdParameter = "/{contactId}";
        public static class ContactControllerRoutes
        {
            public const string Get = ContactControllerBase + ContactIdParameter;    // [HttpGet]
            public const string GetAll = ContactControllerBase;                 // [HttpGet]
            public const string Create = ContactControllerBase;                 // [HttpPost]
            public const string Update = ContactControllerBase + ContactIdParameter; // [HttpPut]
            public const string Delete = ContactControllerBase + ContactIdParameter; // [HttpDelete]
        }

        private const string ContactInfoControllerBase = Base + "/contactInfo";
        private const string ContactInfoIdParameter = "/{contactInfoId}";
        public static class ContactInfoControllerRoutes
        {
            public const string Get = ContactInfoControllerBase + ContactInfoIdParameter;    // [HttpGet]
            public const string GetAll = ContactInfoControllerBase;                 // [HttpGet]
            public const string Create = ContactInfoControllerBase;                 // [HttpPost]
            public const string Update = ContactInfoControllerBase + ContactInfoIdParameter; // [HttpPut]
            public const string Delete = ContactInfoControllerBase + ContactInfoIdParameter; // [HttpDelete]
        }

    }
}
