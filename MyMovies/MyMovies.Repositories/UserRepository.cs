using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using System.Linq;

namespace MyMovies.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyMoviesDbContext context;

        public UserRepository(MyMoviesDbContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User GetByUserName(string username)
        {
            return context.Users.FirstOrDefault(x => x.Username == username);
        }

    }
}
