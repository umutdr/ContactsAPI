using ContactsAPI.Data;
using ContactsAPI.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using ContactsAPI.Configs;

namespace ContactsAPI.Services.IdentityServices
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JWTConfig _jwtConfig;

        public IdentityService(UserManager<IdentityUser> userManager, JWTConfig jwtConfig)
        {
            _userManager = userManager;
            _jwtConfig = jwtConfig;
        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            /*
                         if (user != null)
                            return new AuthenticationResult
                            {
                                Errors = new[] { "User with this email is not found." },
                            };

                        var isUserPasswordValid = await _userManager.CheckPasswordAsync(user, password);

                        if (!isUserPasswordValid)
                        {
                            return new AuthenticationResult
                            {
                                Errors = new[] { "Email and Password combination is wrong" },
                            };
                        }
             */

            var isUserPasswordValid = await _userManager.CheckPasswordAsync(user, password);

            if (!isUserPasswordValid)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "Email and Password combination is might be wrong" },
                };
            }

            return GenerateAuthResultForUser(user);
        }

        public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        {
            // Bu satırı, await ifadesini kaldırıp tetiklersek 
            // _userManager.FindByEmailAsync() metodu aslinda var olmayan bir user dönüyor ????????????????
            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
                return new AuthenticationResult
                {
                    Errors = new[] { "Another user using this email address" },
                };

            var newUser = new IdentityUser
            {
                Email = email,
                UserName = email
            };

            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createdUser.Errors.Select(x => x.Description),
                };
            }

            return GenerateAuthResultForUser(newUser);
        }

        private AuthenticationResult GenerateAuthResultForUser(IdentityUser newUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, newUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", newUser.Id),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
            };
        }
    }
}
