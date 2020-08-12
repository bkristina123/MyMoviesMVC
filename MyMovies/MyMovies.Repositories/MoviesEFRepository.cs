using Microsoft.EntityFrameworkCore;
using MyMovies.Data;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Repositories
{
    public class MoviesEFRepository : IMoviesRepository
    {
        private readonly MyMoviesDbContext context;

        public MoviesEFRepository(MyMoviesDbContext context)
        {
            this.context = context;
        }

        public void Add(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = context.Movies.FirstOrDefault(x => x.Id.Equals(id));

            context.Movies.Remove(movie);

            context.SaveChanges();

        }

        public List<Movie> GetAll()
        {
            return context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return context.Movies
                .Include(x => x.MovieComments)
                    .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<Movie> GetByTitle(string title = null)
        {
            return context.Movies.Where(x =>
            string.IsNullOrEmpty(title) ||
            x.Title.Contains(title))
                .ToList();
        }

        public void Update(Movie movie)
        {
            context.Movies.Update(movie);
            context.SaveChanges();
        }
    }
}
