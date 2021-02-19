using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests.Identity;
using ContactsAPI.Contracts.V1.Responses.Identity;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace ContactsAPI.Tests
{
    public class IdentityControllerTests : IntegrationTest
    {
        [Fact]
        public async Task Register_ShouldReturnAuthSuccessResponseAndValidJWT()
        {
            // Arrange
            var testContact = new UserRegistrationRequest
            {
                Email = ReturnRandomGuidPart() + "@mail.com",
                Password = "Test123#"
            };

            // Act
            var userRegistrationResponse
                = await httpClient
                .PostAsJsonAsync(
                    APIRoutes.IdentityControllerRoutes.Register,
                    testContact);

            // Assert

            userRegistrationResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var registeredUser = await userRegistrationResponse.Content.ReadAsAsync<AuthSuccessResponse>();
            registeredUser.Should().BeOfType<AuthSuccessResponse>();

            // Authorization işlemi gerçekleştiriliyor
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", registeredUser.Token);

            var authTestResponse
                = await httpClient
                .GetAsync(APIRoutes.IdentityControllerRoutes.AuthTest);

            authTestResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Login_ShouldReturnAuthSuccessResponseAndValidJWT()
        {
            // Arrange
            var testContact = new UserRegistrationRequest
            {
                Email = ReturnRandomGuidPart() + "@mail.com",
                Password = "Test123#"
            };

            var userRegistrationResponse
                = await httpClient
                .PostAsJsonAsync(
                    APIRoutes.IdentityControllerRoutes.Register,
                    testContact);

            userRegistrationResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var registeredUser = await userRegistrationResponse.Content.ReadAsAsync<AuthSuccessResponse>();
            registeredUser.Should().BeOfType<AuthSuccessResponse>();

            // Act
            var userLoginResponse
                = await httpClient
                .PostAsJsonAsync(
                    APIRoutes.IdentityControllerRoutes.Login,
                    testContact);

            // Assert

            userLoginResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var loggedInUser = await userLoginResponse.Content.ReadAsAsync<AuthSuccessResponse>();
            loggedInUser.Should().BeOfType<AuthSuccessResponse>();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loggedInUser.Token);

            var authTestResponse
                = await httpClient
                .GetAsync(APIRoutes.IdentityControllerRoutes.AuthTest);

            authTestResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

    }
}
