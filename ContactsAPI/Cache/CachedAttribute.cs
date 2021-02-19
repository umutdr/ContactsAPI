using ContactsAPI.Services.RedisCacheServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAPI.Cache
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _cacheTime;

        public CachedAttribute(int cacheTime)
        {
            _cacheTime = cacheTime;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //before
            // data önbellekte mevcut mu?
            // if (data != null) return data;

            var cacheConfig = context.HttpContext.RequestServices.GetRequiredService<RedisCacheConfig>();

            if (cacheConfig.IsEnabled == false)
            {
                Console.WriteLine("Redis cache is not enabled");
                await next();
                return;
            }

            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IRedisCacheService>();

            var cacheKey = GenerateCacheKeyByRequest(context.HttpContext.Request);
            var cachedResponse = await cacheService.GetCachedResponseAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = (int)HttpStatusCode.OK
                };

                context.Result = contentResult;

                Console.WriteLine($"Cache found. Key: {cacheKey}");

                return;
            }

            var executedContext = await next();

            //after
            // if (data == null)
            // controllerdan datayı al
            // datayı önbelleğe kopyala
            // önbellekten datayı döndür

            if (executedContext.Result is OkObjectResult okObjectResult)
            {
                await cacheService.CreateCacheResponseAsync(cacheKey, okObjectResult.Value, TimeSpan.FromSeconds(_cacheTime));
                Console.WriteLine($"Cache not found but created. Key: {cacheKey}");
            }
        }

        private static string GenerateCacheKeyByRequest(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();

            keyBuilder.Append($"{request.Path}"); // api/v1/{controller}

            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"{key}-{value}");
            }

            string cacheKey = keyBuilder.ToString();

            // key olarak route kullandigim icin en bastaki '/' karakterinin olmamasi gerekiyor
            if (cacheKey[0] == '/')
                cacheKey = cacheKey.Remove(0, 1);

            return cacheKey;
        }
    }
}
