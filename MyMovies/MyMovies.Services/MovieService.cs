using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Services
{
    public class MovieService : IMoviesService
    {
        private readonly IMoviesRepository moviesRepo;

        public MovieService(IMoviesRepository moviesRepo)
        {
            this.moviesRepo = moviesRepo;
        }

        public IEnumerable<Movie> GetAll()
        {
            return moviesRepo.GetAll();
        }

        public Movie GetById(int id)
        {
            return moviesRepo.GetById(id);

        }

        public Movie GetMovieDetails(int id)
        {
            var movie = moviesRepo.GetById(id);
            movie.Views += 1;
            moviesRepo.Update(movie);

            return movie;
        }

        public void CreateMovie(Movie movie)
        {
            movie.DateCreated = DateTime.Now;
            moviesRepo.Add(movie);
        }

        public IEnumerable<Movie> GetByTitle(string title)
        {
            return moviesRepo.GetByTitle(title);
        }

        public void Delete(int id)
        {
            moviesRepo.Delete(id);
        }

        public void Update(Movie movie)
        {
            moviesRepo.Update(movie);
        }

        public SidebarData GetSidebarData()
        {
            var movieCount = 3;
            var movies = moviesRepo.GetAll();

            var topMovies = movies
                .OrderByDescending(x => x.Views)
                .Take(movieCount)
                .Select(x => new SidebarMovie() {
                    Id = x.Id,
                    Title = x.Title,
                    DateCreated = x.DateCreated.Value,
                    Views = x.Views
                })
                .ToList();

            var recentMovies = movies
                .OrderByDescending(x => x.DateCreated)
                .Take(movieCount)
                .Select(x => new SidebarMovie()
                {
                    Id = x.Id,
                    Title = x.Title,
                    DateCreated = x.DateCreated.Value,
                    Views = x.Views
                })
                .ToList();

            var sidebarData = new SidebarData()
            {
                TopMovies = topMovies,
                RecentMovies = recentMovies
            };

            return sidebarData;
        }
    }
}
