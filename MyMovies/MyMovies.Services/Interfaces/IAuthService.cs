using Microsoft.AspNetCore.Http;
using MyMovies.Services.DtoModels;
using System.Threading.Tasks;

namespace MyMovies.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> SignInAsync(string username, string password, HttpContext httpContext);
        Task SignOutAsync(HttpContext httpContext);
        SignUpResponse SignUp(string username, string password);

    }
}
