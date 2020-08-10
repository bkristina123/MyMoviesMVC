using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System;

namespace MyMovies.Services
{
    public class MovieCommentsService : IMovieCommentsService
    {
        private readonly IMovieCommentsRepository movieCommentsRepo;

        public MovieCommentsService(IMovieCommentsRepository movieCommentsRepo)
        {
            this.movieCommentsRepo = movieCommentsRepo;
        }

        public void Add(string comment, int movieId, int userId)
        {
            var movieComment = new MovieComment
            {
                Comment = comment,
                MovieId = movieId,
                UserId = userId,
                DateCreated = DateTime.Now
            };

            movieCommentsRepo.Add(movieComment);
        }
    }
}
