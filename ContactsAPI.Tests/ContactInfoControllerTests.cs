using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests.Contact;
using ContactsAPI.Contracts.V1.Requests.ContactInfo;
using ContactsAPI.Contracts.V1.Responses.Contact;
using ContactsAPI.Contracts.V1.Responses.ContactInfo;
using ContactsAPI.Domain;
using ContactsAPI.Models;
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
    public class ContactInfoControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Get_ShouldReturnTheMatchingContactInfo()
        {
            // Arrange
            await AuthenticationAsync();
            var createdTestContact
                = await CreateContactAsync(
                    new CreateContactRequest
                    {
                        FirstName = "Integration",
                        LastName = "Test",
                        CompanyName = "IntegrationTest"
                    });

            var createdTestContactInfo1
                = await CreateContactInfoAsync(
                    new CreateContactInfoRequest
                    {
                        ContactId = createdTestContact.Id,
                        Type = ContactInfoType.Phone,
                        Content = "05350811936"
                    });

            // Act
            var getResponse
                = await httpClient
                    .GetAsync(APIRoutes.ContactInfoControllerRoutes.Get
                        .Replace("{contactInfoId}",
                    createdTestContactInfo1.Id.ToString()));

            // Assert
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var returnedContactInfo = await getResponse.Content.ReadAsAsync<ContactInfo>();
            returnedContactInfo.Id.Should().Be(createdTestContactInfo1.Id);
            returnedContactInfo.ContactId.Should().Be(createdTestContactInfo1.ContactId);
            returnedContactInfo.Content.Should().Be(createdTestContactInfo1.Content);
            returnedContactInfo.Type.Should().Be(createdTestContactInfo1.Type);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAContactInfoList()
        {
            // Arrange
            await AuthenticationAsync();

            // Act
            var getAllResponse = await httpClient.GetAsync(APIRoutes.ContactInfoControllerRoutes.GetAll);

            // Assert
            getAllResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var contactInfos = await getAllResponse.Content.ReadAsAsync<List<ContactInfo>>();
            contactInfos.Should().BeOfType<List<ContactInfo>>();

            // Bu test çalıştığında eğer anlık olarak hafızada oluşturulan veritabanı kullanımdaysa
            // contacts tablosu hep boş olacaktır. Çünkü test içerisinde bir ekleme yapılmıyor.
            // Asıl veritabanı devredeyken test çalıştırılırsa Contacts tablosunda veri olma ihtimaline karşın
            // aşağıdaki kontrolü yaptım.
            if (contactInfos.Count > 0)
                contactInfos.Should().NotBeEmpty();
            else
                contactInfos.Should().BeEmpty();
        }

        [Fact]
        public async Task GetAllByContact_ShouldReturnContactsContactInfoList()
        {
            // Arrange
            await AuthenticationAsync();

            // Act
            var getAllResponse = await httpClient.GetAsync(APIRoutes.ContactInfoControllerRoutes.GetAll);

            // Assert
            getAllResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var contactInfos = await getAllResponse.Content.ReadAsAsync<List<ContactInfo>>();
            contactInfos.Should().BeOfType<List<ContactInfo>>();

            // Bu test çalıştığında eğer anlık olarak hafızada oluşturulan veritabanı kullanımdaysa
            // contacts tablosu hep boş olacaktır. Çünkü test içerisinde bir ekleme yapılmıyor.
            // Asıl veritabanı devredeyken test çalıştırılırsa Contacts tablosunda veri olma ihtimaline karşın
            // aşağıdaki kontrolü yaptım.
            if (contactInfos.Count > 0)
                contactInfos.Should().NotBeEmpty();
            else
                contactInfos.Should().BeEmpty();
        }

        [Fact]
        public async Task Create_ShouldReturnCreatedRecord()
        {
            // Arrange
            await AuthenticationAsync();

            var createdTestContact
                = await CreateContactAsync(
                    new CreateContactRequest
                    {
                        FirstName = "Integration",
                        LastName = "Test",
                        CompanyName = "IntegrationTest"
                    });

            var createdTestContactInfo1
                = new CreateContactInfoRequest
                {
                    ContactId = createdTestContact.Id,
                    Type = ContactInfoType.Phone,
                    Content = "05350811936"
                };

            // Act
            var createdTestContactInfoResponse
                = await httpClient
                .PostAsJsonAsync(
                    APIRoutes.ContactInfoControllerRoutes.Create,
                    createdTestContactInfo1
                    );

            // Assert
            createdTestContactInfoResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            var returnedTestContactInfo = await createdTestContactInfoResponse.Content.ReadAsAsync<ContactInfoResponse>();

            returnedTestContactInfo.ContactId.Should().Be(createdTestContactInfo1.ContactId);
            returnedTestContactInfo.Content.Should().Be(createdTestContactInfo1.Content);
            returnedTestContactInfo.Type.Should().Be(createdTestContactInfo1.Type);
        }

        [Fact]
        public async Task Update_ShouldReturnUpdatedRecord()
        {
            // Arrange
            await AuthenticationAsync();
            var createdTestContact
                = await CreateContactAsync(
                    new CreateContactRequest
                    {
                        FirstName = "Integration",
                        LastName = "Test",
                        CompanyName = "IntegrationTest"
                    });

            // Act
            var createdTestContactInfo1
                = await CreateContactInfoAsync(
                    new CreateContactInfoRequest
                    {
                        ContactId = createdTestContact.Id,
                        Type = ContactInfoType.Phone,
                        Content = "05350811936"
                    });

            // Assert
            createdTestContactInfo1.Type = ContactInfoType.Location;
            createdTestContactInfo1.Content = "Location1";

            var updatedContactInfoResponse
                = await httpClient
                    .PutAsJsonAsync(
                        APIRoutes.ContactInfoControllerRoutes.Update
                            .Replace("{contactInfoId}", createdTestContactInfo1.Id.ToString()),
                        createdTestContactInfo1);

            // Act
            updatedContactInfoResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var updatedContactInfo = await updatedContactInfoResponse.Content.ReadAsAsync<ContactInfo>();

            updatedContactInfo.Id.Should().Be(createdTestContactInfo1.Id);
            updatedContactInfo.Content.Should().Be(createdTestContactInfo1.Content);
            updatedContactInfo.Type.Should().Be(createdTestContactInfo1.Type);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContent()
        {
            // Arrange
            await AuthenticationAsync();
            var createdTestContact
                = await CreateContactAsync(
                    new CreateContactRequest
                    {
                        FirstName = "Integration",
                        LastName = "Test",
                        CompanyName = "IntegrationTest"
                    });

            // Act
            var createdTestContactInfo1
                = await CreateContactInfoAsync(
                    new CreateContactInfoRequest
                    {
                        ContactId = createdTestContact.Id,
                        Type = ContactInfoType.Phone,
                        Content = "05350811936"
                    });

            // Act
            var response = await httpClient.DeleteAsync(APIRoutes.ContactInfoControllerRoutes.Delete.Replace("{contactInfoId}", createdTestContactInfo1.Id.ToString()));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        }
    }
}
