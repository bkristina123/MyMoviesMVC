using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        IEnumerable<Movie> GetByTitle(string title);
        void Delete(int id);
        void Update(Movie movie);
    }
}
