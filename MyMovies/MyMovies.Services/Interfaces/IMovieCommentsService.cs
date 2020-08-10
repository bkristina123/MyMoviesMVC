namespace MyMovies.Services.Interfaces
{
    public interface IMovieCommentsService
    {
        void Add(string comment, int movieId, int userId);
    }
}
