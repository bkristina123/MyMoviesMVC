using MyMovies.Data;
using System.Collections.Generic;

namespace MyMovies.Services.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<User> GetAll();
        void Delete(int id);
        User GetById(int id);
        void Update(User user);
    }
}
