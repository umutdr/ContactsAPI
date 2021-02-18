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

        private const string ContactControllerBase = Base + "/contact";
        private const string ContactIdParameter = "/{contactId}";
        public static class ContactControllerRoutes
        {
            public const string Get = ContactControllerBase + ContactIdParameter;
            public const string GetAll = ContactControllerBase;
            public const string Create = ContactControllerBase;
            public const string Update = ContactControllerBase + ContactIdParameter;
            public const string Delete = ContactControllerBase + ContactIdParameter;
        }

        private const string ContactInfoControllerBase = Base + "/contactinfo";
        private const string ContactInfoIdParameter = "/{contactInfoId}";
        private const string ContactInfoTypeParameter = "/{type}";
        private const string ContactInfoByContactPart = "/bycontact";
        public static class ContactInfoControllerRoutes
        {
            public const string Get = ContactInfoControllerBase + ContactInfoIdParameter;
            public const string GetAll = ContactInfoControllerBase;
            public const string GetAllByContact = ContactInfoControllerBase + ContactInfoByContactPart + ContactIdParameter;
            public const string GetAllByContactAndType = ContactInfoControllerBase + ContactInfoByContactPart + ContactIdParameter + ContactInfoTypeParameter;
            public const string Create = ContactInfoControllerBase;
            public const string Update = ContactInfoControllerBase + ContactInfoIdParameter;
            public const string Delete = ContactInfoControllerBase + ContactInfoIdParameter;
        }

        private const string IdentityControllerBase = Base + "/identity";
        public static class IdentityControllerRoutes
        {
            public const string Login = IdentityControllerBase + "/login";
            public const string Register = IdentityControllerBase + "/register";
        }


    }
}
