using E_Commerce_Platform.DataBase.Models;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Platform.Areas.Admin.ViewModels
{
    public class ProductAddViewModel
    {
        [Required(ErrorMessage = "Product name is required.")]
        
        public string Name { get; set; }

        [Required(ErrorMessage = "Product description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        
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
