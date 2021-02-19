﻿using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Services.RedisCacheServices
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan cacheTime)
        {
            if (response == null)
                return;

            var serializedResponse = JsonConvert.SerializeObject(response);

            await _distributedCache
                .SetStringAsync(cacheKey,
                    serializedResponse,
                    new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = cacheTime,
                    });
        }

        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);

            return string.IsNullOrEmpty(cachedResponse) ? null : cachedResponse;
        }
    }
}
