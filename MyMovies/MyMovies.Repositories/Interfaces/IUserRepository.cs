using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetByUserName(string username);
        void Add(User user);
    }
}
