using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesFileRepository : IMoviesRepository
    {
        public List<Movie> Movies { get; set; }

        public MoviesFileRepository()
        {
            var movies = File.ReadAllText("movies.txt");

            Movies = JsonConvert.DeserializeObject<List<Movie>>(movies);

        }

        public List<Movie> GetAll()
        {
            return Movies;
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Movie movie)
        {
            var movies = GetAll();
            var maxId = movies.Max(x => x.Id);
            movie.Id = maxId + 1;

            Movies.Add(movie);
            var json = JsonConvert.SerializeObject(Movies);

            File.WriteAllText("movies.txt", json);
        }

        public IEnumerable<Movie> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
