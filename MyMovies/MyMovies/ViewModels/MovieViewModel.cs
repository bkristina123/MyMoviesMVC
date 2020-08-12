using MyMovies.Data;
using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;

namespace MyMovies.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Cast { get; set; }

        public DateTime? DateCreated { get; set; }

        public int Views { get; set; }

        public List<MovieCommentViewModel> MovieComments{ get; set; }

        public SidebarData SidebarData { get; set; }
    }
}
