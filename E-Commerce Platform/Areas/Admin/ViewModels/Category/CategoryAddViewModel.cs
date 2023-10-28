using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Platform.Areas.Admin.ViewModels.Category
{
    public class CategoryAddViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Name must be between 10 and 50 characters!!!")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 50, ErrorMessage = "Name must be between 50 and 500 characters!!!")]
        public string Description { get; set; }
    }
}
