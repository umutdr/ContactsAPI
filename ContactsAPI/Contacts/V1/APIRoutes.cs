using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Contacts.V1
{
    public static class APIRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version + "/";

        public static class PostsRoutes
        {
            public const string Posts = Base + nameof(Posts);
        }
    }
}
