using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        public IActionResult SignIn()
        {
            var signIn = new SignInModel();

            return View(signIn);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel signInModel, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var isSignedIn = await authService.SignInAsync(signInModel.Username, signInModel.Password, HttpContext);

                if(isSignedIn)
                {
                    if(!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    } else
                    {
                        return RedirectToAction("Overview", "Movies");
                    }

                } else
                {
                    ModelState.AddModelError(string.Empty, "Username or password is incorrect");
                    return View(signInModel);
                }

            }

            return View(signInModel);
        }

        public IActionResult SignUp()
        {
            var signUpModel = new SignUpModel();
            return View(signUpModel);
        }

        [HttpPost]
        public IActionResult SignUp(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var response = authService.SignUp(signUpModel.Username, signUpModel.Password);
                if (response.IsSuccesful)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response.Message);
                    return View(signUpModel);
                }

            }

            return View(signUpModel);
        }

        public async Task<IActionResult> SignOut()
        {
            await authService.SignOutAsync(HttpContext);
            return RedirectToAction("Overview", "Movies");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}