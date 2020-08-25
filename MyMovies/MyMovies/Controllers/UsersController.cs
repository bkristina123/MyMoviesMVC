using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Helpers;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System.Linq;

namespace MyMovies.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }


        public IActionResult ModifyUsersOverview()
        {
            var users = usersService.GetAll()
                .Select(x => x.ConvertToUserViewModel())
                .ToList();

            return View(users);
        }

        public IActionResult EditUser(int id)
        {
            var user = usersService.GetById(id)
                .ConvertToUserViewModel();

            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(UserViewModel user)
        {

            if (ModelState.IsValid)
            {
                var response = usersService.Update(user.ConvertToUserEntity());

                if (response.IsSuccesful)
                {
                    return RedirectToAction("ModifyUsersOverview");

                } else
                {
                    ModelState.AddModelError("", response.Message);
                }
            }

            return View(user);
        }

        public IActionResult DeleteUser(int id)
        {
            usersService.Delete(id);
            return RedirectToAction("ModifyUsersOverview");
        }
    }
}