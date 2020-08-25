using MyMovies.Data;
using MyMovies.Services.DtoModels;
using System.Collections.Generic;

namespace MyMovies.Services.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<User> GetAll();
        void Delete(int id);
        User GetById(int id);
        ModifyUsersResponse Update(User user);
    }
}
