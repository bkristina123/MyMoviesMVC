using MyMovies.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Cast { get; set; }

        public DateTime? DateCreated { get; set; }

        public int Views { get; set; }

        public List<MovieCommentViewModel> MovieComments{ get; set; }

        public SidebarData SidebarData { get; set; }
    }
}
