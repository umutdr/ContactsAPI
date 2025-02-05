﻿using ContactsAPI.Data;
using ContactsAPI.Services;
using ContactsAPI.Services.ContactInfoServices;
using ContactsAPI.Services.ContactServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Installers
{
    public class DataInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactInfoService, ContactInfoService>();
        }
    }
}
