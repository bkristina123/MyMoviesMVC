using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMovieCommentsRepository
    {
        void Add(MovieComment comment);
    }
}
