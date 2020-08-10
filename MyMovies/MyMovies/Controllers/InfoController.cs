using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyMovies.Controllers
{
    public class InfoController : Controller
    {

        public IActionResult AboutUs()
        {
            ViewBag.CreatorName = "Kristina";
            ViewBag.CurrentDate = DateTime.Now.ToString();
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}