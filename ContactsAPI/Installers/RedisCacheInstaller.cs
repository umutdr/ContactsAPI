using ContactsAPI.Cache;
using ContactsAPI.Services.RedisCacheServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Installers
{
    public class RedisCacheInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            var redisCacheConfig = new RedisCacheConfig();
            Configuration.GetSection(nameof(RedisCacheConfig)).Bind(redisCacheConfig);
            services.AddSingleton(redisCacheConfig);

            //if (redisCacheConfig.IsEnabled == false)
            //    return;

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisCacheConfig.ConnectionString;
            });

            services.AddSingleton<IRedisCacheService, RedisCacheService>();
        }
    }
}
