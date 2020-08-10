using MyMovies.Data;
using MyMovies.Repositories.Interfaces;

namespace MyMovies.Repositories
{
    public class MovieCommentsRepository : IMovieCommentsRepository
    {
        private readonly MyMoviesDbContext context;

        public MovieCommentsRepository(MyMoviesDbContext context)
        {
            this.context = context;
        }

        public void Add(MovieComment comment)
        {
            context.MovieComments.Add(comment);
            context.SaveChanges();
        }
    }
}
 