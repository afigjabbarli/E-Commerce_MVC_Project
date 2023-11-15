using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Platform.ViewModels.User
{
    public class UserLoginViewModel
    {

        [Required(ErrorMessage = "Membership password is required!")]
        [StringLength(8, ErrorMessage = "The data must consist of exactly 8 characters!")]
        [RegularExpression(@"^USR\d{5}$", ErrorMessage = "Invalid data!")]
        public string MembershipPassword { get; set; }
        
    }
}
