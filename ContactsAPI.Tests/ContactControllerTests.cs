using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests.Contact;
using ContactsAPI.Domain;
using FluentAssertions;
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
        public async Task Get_WhileContactIdMatchesAnyRecord_ShouldReturnTheMatchingRecord()
        {
            // Arrange
            await AuthenticatiAsync();
            var createdTestContact
                = await CreateContactAsync(
                    new CreateContactRequest
                    {
                        FirstName = "Integration",
                        LastName = "Test",
                        CompanyName = "IntegrationTest"
                    });

            // Act
            var response = await httpClient.GetAsync(APIRoutes.ContactControllerRoutes.Get.Replace("{contactId}", createdTestContact.Id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedTestContact = await response.Content.ReadAsAsync<Contact>();

            returnedTestContact.Id.Should().Be(createdTestContact.Id);
            returnedTestContact.FirstName.Should().Be(createdTestContact.FirstName);
            returnedTestContact.LastName.Should().Be(createdTestContact.LastName);
            returnedTestContact.CompanyName.Should().Be(createdTestContact.CompanyName);
        }

        [Fact]
        public async Task GetAll_WhileContactsTableInDbIsEmpty_ShouldReturnEmpty()
        {
            // Arrange
            await AuthenticatiAsync();

            // Act
            var response = await httpClient.GetAsync(APIRoutes.ContactControllerRoutes.GetAll);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<Contact>>()).Should().BeEmpty();
        }
    }
}
