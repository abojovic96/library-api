using System.ComponentModel.DataAnnotations;

namespace Books.API.Models.Base
{
    public class AuthenticationControllerRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
