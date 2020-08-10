using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Services.Interfaces;

namespace MyMovies.Controllers
{
    public class MovieCommentsController : Controller
    {
        private readonly IMovieCommentsService movieCommentsService;

        public MovieCommentsController(IMovieCommentsService movieCommentsService)
        {
            this.movieCommentsService = movieCommentsService;
        }

        [Authorize]
        public IActionResult AddComment(string comment, int movieId)
        {
            if(!String.IsNullOrEmpty(comment))
            {
                var userId = Convert.ToInt32(User.FindFirst("Id").Value);
                movieCommentsService.Add(comment, movieId, userId);
            }
            return RedirectToAction("Details", "Movies", new { id = movieId });
        }
    }
}