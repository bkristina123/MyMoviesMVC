using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesSqlRepository : IMoviesRepository
    {
        public void Add(Movie movie)
        {
            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = MyMoviesSqlDemo; Integrated Security = true"))
            {
                cnn.Open();
                var query = @"insert into Movies (Title, Description, ImageUrl, Cast)
                              values(@Title, @Description, @ImageUrl, @Cast)";

                var cmd = new SqlCommand(query, cnn);
                cmd.Parameters.AddWithValue("@Title", movie.Title);
                cmd.Parameters.AddWithValue("@Description", movie.Description);
                cmd.Parameters.AddWithValue("@ImageUrl", movie.ImageUrl);
                cmd.Parameters.AddWithValue("@Cast", movie.Cast);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetAll()
        {
            var result = new List<Movie>();

            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = MyMoviesSqlDemo; Integrated Security = true"))
            {
                cnn.Open();

                var cmd = new SqlCommand("SELECT * FROM Movies", cnn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var movie = new Movie
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        ImageUrl = reader.GetString(3),
                        Cast = reader.GetString(4)
                    };

                    result.Add(movie);
                }
            }

            return result;
        }

        public Movie GetById(int id)
        {
            Movie result = null;

            using (var cnn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog = MyMoviesSqlDemo; Integrated Security = true"))
            {
                cnn.Open();

                var cmd = new SqlCommand($"SELECT * FROM Movies where id = @Id", cnn);
                cmd.Parameters.AddWithValue("@Id", id);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = new Movie
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        ImageUrl = reader.GetString(3),
                        Cast = reader.GetString(4)
                    };

                }
            }

            return result;

        }

        public IEnumerable<Movie> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void Update(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
