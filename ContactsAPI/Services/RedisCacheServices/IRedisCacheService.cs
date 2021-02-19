using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Services.RedisCacheServices
{
    public interface IRedisCacheService
    {
        Task CreateCacheResponseAsync(string cacheKey, object response, TimeSpan cacheTime);

        Task<string> GetCachedResponseAsync(string cacheKey);

        Task DeleteCachedResponseAsync(string[] cacheKey);

    }
}
