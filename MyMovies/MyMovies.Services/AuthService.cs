using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyMovies.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;

        public AuthService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public async Task<bool> SignInAsync(string username, string password, HttpContext httpContext)
        {
            var user = userRepository.GetByUserName(username);

            if(user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("IsAdmin", user.IsAdmin.ToString()),
                    new Claim("Id", user.Id.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await httpContext.SignInAsync(principal);

                return true;
            };

            return false;
        }

        public async Task SignOutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        public SignUpResponse SignUp(string username, string password)
        {
            var user = userRepository.GetByUserName(username);
            var response = new SignUpResponse();

            if (user == null)
            {
                var newUser = new User
                {
                    Username = username,
                    Password = BCrypt.Net.BCrypt.HashPassword(password)
                };

                userRepository.Add(newUser);
                response.IsSuccesful = true;
                return response;

            }
            else
            {
                response.IsSuccesful = false;
                response.Message = "User with this username already exists";
                return response;
            }

        }
    }
}
