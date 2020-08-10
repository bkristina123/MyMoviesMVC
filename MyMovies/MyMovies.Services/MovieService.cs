using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;
using System.Collections.Generic;

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

    }
}
