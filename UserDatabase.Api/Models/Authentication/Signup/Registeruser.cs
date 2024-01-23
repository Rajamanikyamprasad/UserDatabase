using System.ComponentModel.DataAnnotations;

namespace UserDatabase.Api.Models.Authentication.Signup
{
    public class Registeruser
    {
        [Required(ErrorMessage = "User name is required")]

        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email {  get; set;}

        [Required(ErrorMessage = "password is required")]
        public string? Password { get; set;}

    }
}
