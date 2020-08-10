using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyMovies.Repositories
{
    public class MovieRepository : IMoviesRepository
    {
        public List<Movie> Movies { get; set; }

        public MovieRepository()
        {
            Movies = new List<Movie>();

            var movie1 = new Movie()
            {
                Id = 1,
                Title = "Joker",
                Cast = "Joaquin Phoenix, Robert De Niro, Zazie Beetz",
                Description = "In Gotham City, mentally troubled comedian Arthur Fleck is disregarded and mistreated by society. He then embarks on a downward spiral of revolution and bloody crime. This path brings him face-to-face with his alter-ego: the Joker.",
                ImageUrl = "https://m.media-amazon.com/images/M/MV5BNGVjNWI4ZGUtNzE0MS00YTJmLWE0ZDctN2ZiYTk2YmI3NTYyXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
            };


            var movie2 = new Movie()
            {
                Id = 2,
                Title = "Avengers: Endgame",
                Description = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                Cast = "Robert Downey Jr., Chris Evans, Mark Ruffalo ",
                ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTc5MDE2ODcwNV5BMl5BanBnXkFtZTgwMzI2NzQ2NzM@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
            };

            var movie3 = new Movie()
            {
                Id = 3,
                Title = "1917",
                Description = "April 6th, 1917. As a regiment assembles to wage war deep in enemy territory, two soldiers are assigned to race against time and deliver a message that will stop 1,600 men from walking straight into a deadly trap.",
                Cast = "Dean-Charles Chapman, George MacKay, Daniel Mays",
                ImageUrl = "https://m.media-amazon.com/images/M/MV5BOTdmNTFjNDEtNzg0My00ZjkxLTg1ZDAtZTdkMDc2ZmFiNWQ1XkEyXkFqcGdeQXVyNTAzNzgwNTg@._V1_SY1000_CR0,0,631,1000_AL_.jpg"
            };

            Movies.Add(movie1);
            Movies.Add(movie2);
            Movies.Add(movie3);

        }

        public List<Movie> GetAll()
        {
            var tmp = JsonConvert.SerializeObject(Movies);
            File.WriteAllText("movies.txt", tmp);
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

        }

        public IEnumerable<Movie> GetByTitle(string title)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Movie movie)
        {
            throw new System.NotImplementedException();
        }
    }
}
