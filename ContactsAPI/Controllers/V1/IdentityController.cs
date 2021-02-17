using ContactsAPI.Contracts.V1;
using ContactsAPI.Contracts.V1.Requests.Identity;
using ContactsAPI.Contracts.V1.Responses.Identity;
using ContactsAPI.Services.IdentityServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Controllers.V1
{
    public class IdentityController : Controller
    {
        private IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(APIRoutes.IdentityControllerRoutes.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

            if (!authResponse.Success)
                return BadRequest(new AuthFailedResponse { Errors = authResponse.Errors });

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
            });
        }

        [HttpPost(APIRoutes.IdentityControllerRoutes.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(error => error.ErrorMessage)),
                });

            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.Success)
                return BadRequest(new AuthFailedResponse { Errors = authResponse.Errors });

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
            });
        }
    }
}
