using System.ComponentModel.DataAnnotations;

namespace MyMovies.ViewModels
{
    public class SignInModel
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "The password must contain at least one captial letter and one digit")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
