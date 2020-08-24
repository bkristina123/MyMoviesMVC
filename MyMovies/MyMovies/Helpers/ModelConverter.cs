using MyMovies.Data;
using MyMovies.Models;
using MyMovies.ViewModels;
using System.Linq;

namespace MyMovies.Helpers
{
    public static class ModelConverter
    {
        public static MovieViewModel ConvertToMovieViewModel(this Movie movie)
        {
            return new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Cast = movie.Cast,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                Views = movie.Views,
                DateCreated = movie.DateCreated,
                MovieComments = movie.MovieComments
                .Select(x => 
                x.ConvertToMovieCommentModel()
                )
                .ToList()
            };
        }

        public static Movie ConvertToMovieEntity(this MovieViewModel movie)
        {
            return new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Cast = movie.Cast,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl,
                Views = movie.Views,
                DateCreated = movie.DateCreated,

            };
        }

        public static MovieCommentViewModel ConvertToMovieCommentModel(this MovieComment movieComment)
        {
            return new MovieCommentViewModel
            {
                Comment = movieComment.Comment,
                DateCreated = movieComment.DateCreated,
                Username = movieComment.User.Username
            };
        }

        public static UserViewModel ConvertToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Username = user.Username,
                IsAdmin = user.IsAdmin
            };
        }

        public static User ConvertToUserEntity(this UserViewModel user)
        {
            return new User
            {
                Id = user.Id,
                Username = user.Username,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
