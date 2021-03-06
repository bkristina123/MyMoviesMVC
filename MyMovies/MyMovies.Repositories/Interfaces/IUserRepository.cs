﻿using MyMovies.Data;
using System.Collections.Generic;

namespace MyMovies.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetByUserName(string username);
        void Add(User user);
        IEnumerable<User> GetAll();
        void Delete(int id);
        User GetById(int id);
        void Update(User user);
    }
}
