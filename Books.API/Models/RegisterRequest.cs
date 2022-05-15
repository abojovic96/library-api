using Books.API.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Books.API.Models
{
    public class RegisterRequest : AuthenticationControllerRequest
    {   
        [Required(ErrorMessage = "Email is requied")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Confrim password is requied")]
        public string confirmPassword { get; set; }
    }
}
