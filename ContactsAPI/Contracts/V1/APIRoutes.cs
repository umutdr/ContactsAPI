using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Contracts.V1
{
    public static class APIRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;

        private const string ContactControllerBase = Base + "/contacts/";

        public static class ContactControllerRoutes
        {
            public const string Get = ContactControllerBase + "{contactId}";
            public const string GetAll = ContactControllerBase;
            public const string Create = ContactControllerBase;
        }
    }
}
