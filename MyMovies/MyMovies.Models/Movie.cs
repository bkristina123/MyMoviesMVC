using MyMovies.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Cast { get; set; }

        public int Views { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }

        public virtual List<MovieComment> MovieComments { get; set; }
    }
}
