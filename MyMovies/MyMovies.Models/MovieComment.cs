using MyMovies.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Data
{
    public class MovieComment
    {
        public int Id { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
