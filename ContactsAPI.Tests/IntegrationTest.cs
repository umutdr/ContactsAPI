using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests.Contact;
using ContactsAPI.Contracts.V1.Requests.Identity;
using ContactsAPI.Contracts.V1.Responses.Contact;
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
    public class IntegrationTest
    {
        protected readonly HttpClient httpClient;

        protected IntegrationTest()
        {
            var appFactory
                = new WebApplicationFactory<Startup>()
                    .WithWebHostBuilder(builder =>
                    {
                        // Bu blogu kaldırırsak test asıl veritabanını kullanacaktır.
                        builder.ConfigureServices(services =>
                        {
                            // Projenin, asıl veritabanıyla iletişim kurmak için kullandığı servis devre dışı bırakıldı.
                            services.RemoveAll(typeof(DataContext));

                            services.AddDbContext<DataContext>(options =>
                            {
                                // Test ortamında asıl veritabanını kullanmak yerine, hafızada oluşturulan asıl veritabanının bir kopyası kullanılacak
                                // Kopya veritabaninin ismini belirtiyor
                                options.UseInMemoryDatabase("TestDatabase");
                            });
                        });
                    });
            httpClient = appFactory.CreateClient();
        }

        protected async Task AuthenticatiAsync()
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJWTAsync());
        }

        protected async Task<ContactResponse> CreateContactAsync(CreateContactRequest request)
        {
            var response = await httpClient.PostAsJsonAsync(APIRoutes.ContactControllerRoutes.Create, request);

            return await response.Content.ReadAsAsync<ContactResponse>();
        }

        private async Task<string> GetJWTAsync()
        {
            var response = await httpClient.PostAsJsonAsync(APIRoutes.IdentityControllerRoutes.Register, new UserRegistrationRequest
            {
                Email = "integration@test.com",
                Password = "Password123#"
            });

            var registrationResponse = await response.Content.ReadAsAsync<AuthSuccessResponse>();

            return registrationResponse.Token; // test ortaminda kullanilacak JWT
        }
    }
}
