using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.Interfaces;
using System.Collections.Generic;

namespace MyMovies.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository userRepository;

        public UsersService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public void Update(User user)
        {
            var dbUser = userRepository.GetById(user.Id);
            dbUser.Username = user.Username;
            dbUser.IsAdmin = user.IsAdmin;

            userRepository.Update(dbUser);
        }
    }
}
