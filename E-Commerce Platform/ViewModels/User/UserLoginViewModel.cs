using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Platform.ViewModels.User
{
    public class UserLoginViewModel
    {

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email password is required.")]
        [MinLength(8, ErrorMessage = "Email password must be at least 8 characters.")]
        [RegularExpression("^[0-9a-zA-Z]*$", ErrorMessage = "Please enter a value containing only digits and lowercase/uppercase letters.")]
        public string Email_Password { get; set; }
    }
}
