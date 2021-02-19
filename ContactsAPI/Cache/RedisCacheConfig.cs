using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Cache
{
    public class RedisCacheConfig
    {
        public bool IsEnabled { get; set; }

        public string ConnectionString { get; set; }
    }
}
