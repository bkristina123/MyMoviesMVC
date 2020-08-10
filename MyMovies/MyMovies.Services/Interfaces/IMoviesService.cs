using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Services.Interfaces
{
    public interface IMoviesService
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void CreateMovie(Movie movie);
        IEnumerable<Movie> GetByTitle(string title);
        Movie GetMovieDetails(int id);
        void Delete(int id);
        void Update(Movie movie);
    }
}

