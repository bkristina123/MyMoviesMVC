using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Data
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required] 
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }

        public virtual List<MovieComment> MovieComments { get; set; }

    }
}
