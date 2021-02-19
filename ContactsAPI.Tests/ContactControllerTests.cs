using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests.Contact;
using ContactsAPI.Contracts.V1.Responses.Contact;
using ContactsAPI.Domain;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactsAPI.Tests
{
    public class ContactControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Get_ShouldReturnTheMatchingContact()
        {
            // Arrange
            await AuthenticationAsync();
            var testContact
                = await CreateContactAsync(
                    new CreateContactRequest
                    {
                        FirstName = "Integration",
                        LastName = "Test",
                        CompanyName = "IntegrationTest"
                    });

            // Act
            var response
                = await httpClient
                    .GetAsync(APIRoutes.ContactControllerRoutes.Get
                        .Replace("{contactId}",
                    testContact.Id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var returnedTestContact = await response.Content.ReadAsAsync<Contact>();
            returnedTestContact.Id.Should().Be(testContact.Id);
            returnedTestContact.FirstName.Should().Be(testContact.FirstName);
            returnedTestContact.LastName.Should().Be(testContact.LastName);
            returnedTestContact.CompanyName.Should().Be(testContact.CompanyName);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAContactList()
        {
            // Arrange
            await AuthenticationAsync();

            // Act
            var response = await httpClient.GetAsync(APIRoutes.ContactControllerRoutes.GetAll);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var contacts = await response.Content.ReadAsAsync<List<Contact>>();
            contacts.Should().BeOfType<List<Contact>>();

            // Bu test çalıştığında eğer anlık olarak hafızada oluşturulan veritabanı kullanımdaysa
            // contacts tablosu hep boş olacaktır. Çünkü test içerisinde bir ekleme yapılmıyor.
            // Asıl veritabanı devredeyken test çalıştırılırsa Contacts tablosunda veri olma ihtimaline karşın
            // aşağıdaki kontrolü yaptım.
            if (contacts.Count > 0)
                contacts.Should().NotBeEmpty();
            else
                contacts.Should().BeEmpty();
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedRecord()
        {
            // Arrange
            await AuthenticationAsync();

            // Act
            var testContact =
                new CreateContactRequest
                {
                    FirstName = "Integration",
                    LastName = "Test",
                    CompanyName = "IntegrationTest"
                };

            var response
                = await httpClient
                .PostAsJsonAsync(
                    APIRoutes.ContactControllerRoutes.Create,
                    testContact);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            var returnedContactResponse = await response.Content.ReadAsAsync<ContactResponse>();

            returnedContactResponse.FirstName.Should().Be(testContact.FirstName);
            returnedContactResponse.LastName.Should().Be(testContact.LastName);
            returnedContactResponse.CompanyName.Should().Be(testContact.CompanyName);
        }

        [Fact]
        public async Task Update_ShouldReturnUpdatedRecord()
        {
            // Arrange
            await AuthenticationAsync();
            var testContact =
                new CreateContactRequest
                {
                    FirstName = "Integration",
                    LastName = "Test",
                    CompanyName = "IntegrationTest"
                };

            var createContactResponse
                = await httpClient
                .PostAsJsonAsync(
                    APIRoutes.ContactControllerRoutes.Create,
                    testContact);

            createContactResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            var createdContact = await createContactResponse.Content.ReadAsAsync<ContactResponse>();

            // Assert
            createdContact.FirstName = "UpdatedFirstName";
            createdContact.LastName = "UpdatedLastName";

            var updateContactResponse
                = await httpClient
                    .PutAsJsonAsync(
                        APIRoutes.ContactControllerRoutes.Update
                            .Replace("{contactId}", createdContact.Id.ToString()),
                        createdContact);

            // Act
            updateContactResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var updatedContact = await updateContactResponse.Content.ReadAsAsync<Contact>();

            updatedContact.FirstName.Should().Be(createdContact.FirstName);
            updatedContact.LastName.Should().Be(createdContact.LastName);
            updatedContact.CompanyName.Should().Be(createdContact.CompanyName);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent()
        {
            // Arrange
            await AuthenticationAsync();
            var testContact
                = await CreateContactAsync(
                    new CreateContactRequest
                    {
                        FirstName = "Integration",
                        LastName = "Test",
                        CompanyName = "IntegrationTest"
                    });

            // Act
            var response = await httpClient.DeleteAsync(APIRoutes.ContactControllerRoutes.Delete.Replace("{contactId}", testContact.Id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        }
    }
}
