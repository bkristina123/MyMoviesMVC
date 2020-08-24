using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Helpers;
using MyMovies.Services.Interfaces;
using MyMovies.ViewModels;
using System.Linq;

namespace MyMovies.Controllers
{
    [Authorize(Policy = "IsAdmin")]
    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
  

            var viewMovies = moviesService.GetByTitle(title)
                .Select(x => x.ConvertToMovieViewModel())
                .ToList();

            var sidebarData = moviesService.GetSidebarData();

            var viewData = new MovieOverviewDataModel
            {
                Movies = viewMovies,
                SidebarData = sidebarData
            };


            return View(viewData);

        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var movieDetails = moviesService.GetMovieDetails(id)
                .ConvertToMovieViewModel();

            var sidebarData = moviesService.GetSidebarData();
            movieDetails.SidebarData = sidebarData;

            return View(movieDetails);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var movie = new MovieViewModel();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Create(MovieViewModel movie)
        {
            if(ModelState.IsValid)
            {
                moviesService.CreateMovie(movie.ConvertToMovieEntity());
                return RedirectToAction("Overview");

            } else
            {
                return View(movie);
            }
        }

        public IActionResult ModifyOverview()
        {
            var movies = moviesService.GetAll()
                .Select(x => x.ConvertToMovieViewModel())
                .ToList();

            return View(movies);
        }


        public IActionResult ModifyMovie(int id)
        {
            var movie = moviesService.GetById(id)
                .ConvertToMovieViewModel();

            return View(movie);
        }

        [HttpPost]
        public IActionResult ModifyMovie(MovieViewModel movie)
        {
            if(ModelState.IsValid)
            {
                moviesService.Update(movie.ConvertToMovieEntity());
                return RedirectToAction("ModifyOverview");
            }

            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            moviesService.Delete(id);
            return RedirectToAction("ModifyOverview");
        }

    }
}
