using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests.Contact;
using ContactsAPI.Contracts.V1.Requests.ContactInfo;
using ContactsAPI.Contracts.V1.Requests.Identity;
using ContactsAPI.Contracts.V1.Responses.Contact;
using ContactsAPI.Contracts.V1.Responses.ContactInfo;
using ContactsAPI.Contracts.V1.Responses.Identity;
using ContactsAPI.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAPI.Tests
{
    public class IntegrationTest /*: IDisposable*/
    {
        protected readonly HttpClient httpClient;
        private readonly IServiceProvider _serviceProvider;
        protected IntegrationTest()
        {
            var appFactory
                = new WebApplicationFactory<Startup>()
                    .WithWebHostBuilder(builder =>
                    {
                        //Bu blogu kaldırırsak test asıl veritabanını kullanacaktır.
                        builder.ConfigureServices(services =>
                        {
                            // Projenin, asıl veritabanıyla iletişim kurmak için kullandığı servis devre dışı bırakıldı.
                            services.RemoveAll(typeof(DataContext));

                            // Test ortamında asıl veritabanı yerine, hafızada oluşturulan TestDatabase adındaki kopya veritabanı kullanılacak
                            services.AddDbContext<DataContext>(options =>
                            {
                                options.UseInMemoryDatabase("TestDatabase");
                            });
                        });
                    });

            _serviceProvider = appFactory.Services;
            httpClient = appFactory.CreateClient();
        }

        protected async Task AuthenticationAsync()
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJWTAsync());
        }

        protected async Task<ContactResponse> CreateContactAsync(CreateContactRequest request)
        {
            var response = await httpClient.PostAsJsonAsync(APIRoutes.ContactControllerRoutes.Create, request);

            return await response.Content.ReadAsAsync<ContactResponse>();
        }

        protected async Task<ContactInfoResponse> CreateContactInfoAsync(CreateContactInfoRequest request)
        {
            var response = await httpClient.PostAsJsonAsync(APIRoutes.ContactInfoControllerRoutes.Create, request);

            return await response.Content.ReadAsAsync<ContactInfoResponse>();
        }

        private async Task<string> GetJWTAsync()
        {
            var response = await httpClient.PostAsJsonAsync(APIRoutes.IdentityControllerRoutes.Register, new UserRegistrationRequest
            {
                // 
                Email = ReturnRandomGuidPart() + "@test.com",
                Password = "Password123#"
            });

            var registrationResponse = await response.Content.ReadAsAsync<AuthSuccessResponse>();

            return registrationResponse.Token; // test ortaminda kullanilacak JWT
        }

        protected static string ReturnRandomGuidPart()
        {
            return (Guid.NewGuid().ToString().Replace("-", "").Substring(0, 15));
        }

        //public void Dispose()
        //{
        //    using (var serviceScope = _serviceProvider.CreateScope())
        //    {
        //        var dataContext = serviceScope.ServiceProvider.GetService<DataContext>();
        //        dataContext.Database.EnsureDeleted();
        //    }
        //}

    }
}
