using MyMovies.Data;
using MyMovies.Repositories.Interfaces;
using MyMovies.Services.DtoModels;
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

        public ModifyUsersResponse Update(User user)
        {
            var response = new ModifyUsersResponse();

            var currentUser = userRepository.GetByUserName(user.Username);

            if(currentUser == null || currentUser.Id == user.Id)
            {
                var dbUser = userRepository.GetById(user.Id);
                dbUser.Username = user.Username;
                dbUser.IsAdmin = user.IsAdmin;

                response.IsSuccesful = true;

                userRepository.Update(dbUser);

            } else
            {
                response.IsSuccesful = false;
                response.Message = "Username already exists";
            }

            return response;
        }
    }
}
