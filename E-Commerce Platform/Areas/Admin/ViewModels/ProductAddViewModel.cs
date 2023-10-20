using E_Commerce_Platform.DataBase.Models;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Platform.Areas.Admin.ViewModels
{
    public class ProductAddViewModel
    {
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Product name should be between 3 and 200 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Product price is not valid.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "At least one category must be selected.")]
        public int[] CategoryIds { get; set; }
        public List<Category> Categories { get; set; }

        [Required(ErrorMessage = "At least one size must be selected.")]
        public int[] SizeIds { get; set; }
        public List<Size> Sizes { get; set; }

        [Required(ErrorMessage = "At least one color must be selected.")]
        public int[] ColorIds { get; set; }
        public List<Color> Colors { get; set; }

        [Required(ErrorMessage = "You must add a product image.")]
        public IFormFile Image { get; set; }
    }

}
