using ContactsAPI.Cache;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly RedisCacheConfig _redisCacheConfig;

        public RedisCacheService(IDistributedCache distributedCache, RedisCacheConfig redisCacheConfig)
        {
            _distributedCache = distributedCache;
            _redisCacheConfig = redisCacheConfig;
        }

        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            if (_redisCacheConfig.IsEnabled == false)
                return null;

            var cachedResponse = await _distributedCache.GetStringAsync(cacheKey);

            return string.IsNullOrEmpty(cachedResponse) ? null : cachedResponse;
        }

        public async Task CreateCacheResponseAsync(string cacheKey, object response, TimeSpan cacheTime)
        {
            if (response == null || _redisCacheConfig.IsEnabled == false)
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

        public async Task DeleteCachedResponseAsync(string[] cacheKeys)
        {
            if (_redisCacheConfig.IsEnabled == false)
                return;

            string _cacheKey;
            foreach (var cacheKey in cacheKeys)
            {
                _cacheKey = cacheKey;
                // key olarak route kullandigim icin en bastaki '/' karakterinin olmamasi gerekiyor
                if (_cacheKey[0] == '/')
                    _cacheKey = _cacheKey.Remove(0, 1);

                await _distributedCache.RemoveAsync(_cacheKey);

                Console.WriteLine($"#@#@#@ #@#@#@ Cached Data is Updated. Key: {_cacheKey} removed from cache.");
            }
        }
    }
}
