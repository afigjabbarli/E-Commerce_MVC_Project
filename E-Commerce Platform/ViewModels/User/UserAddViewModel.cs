using E_Commerce_Platform.Constants;

namespace E_Commerce_Platform.ViewModels.User
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserAddViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be between 2 and 50 characters!!!")]
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "The input must start with an uppercase letter and contain only lowercase letters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Surname must be between 2 and 50 characters!!!")]
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "The input must start with an uppercase letter and contain only lowercase letters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email password is required.")]
        [MinLength(8, ErrorMessage = "Email password must be at least 8 characters!!!")]
        [RegularExpression("^[0-9a-zA-Z]*$", ErrorMessage = "Please enter a value containing only digits and lowercase/uppercase letters.")]
        public string EmailPassword { get; set; }

        [Required(ErrorMessage = "PIN is required.")]
        [RegularExpression("^[0-9A-Z]{7}$", ErrorMessage = "PIN must be a 7-digit number!!!")]
        public string PIN { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Account balance is required.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter a valid numeric value.")]
        [Range(0, double.MaxValue, ErrorMessage = "Account balance must be a non-negative number!!!")]
        public decimal AccountBalance { get; set; }

        [Required(ErrorMessage = "Physical image name is required.")]
        public string PhysicalImageName { get; set; }
    }

}
