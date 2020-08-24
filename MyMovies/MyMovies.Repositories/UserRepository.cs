using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using System.Collections.Generic;
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

        public void Delete(int id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id.Equals(id));

            context.Users.Remove(user);
            context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetById(int id)
        {
            return context.Users.FirstOrDefault(x => x.Id.Equals(id));
        }

        public User GetByUserName(string username)
        {
            return context.Users.FirstOrDefault(x => x.Username.Equals(username));
        }

        public void Update(User user)
        {
            context.Update(user);
            context.SaveChanges();
        }
    }
}
