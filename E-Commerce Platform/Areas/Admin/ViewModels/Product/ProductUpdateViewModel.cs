using E_Commerce_Platform.DataBase.Models;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Platform.Areas.Admin.ViewModels.Product
{
    public class ProductUpdateViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product price is required.")]

        public decimal Price { get; set; }

        [Required(ErrorMessage = "At least one category must be selected.")]
        public int[] CategoryIds { get; set; }
        public List<E_Commerce_Platform.DataBase.Models.Category>? Categories { get; set; }

        [Required(ErrorMessage = "At least one size must be selected.")]
        public int[] SizeIds { get; set; }
        public List<Size>? Sizes { get; set; }

        [Required(ErrorMessage = "At least one color must be selected.")]
        public int[] ColorIds { get; set; }
        public List<E_Commerce_Platform.DataBase.Models.Color>? Colors { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "You must add a product image.")]
        public IFormFile Image { get; set; }

        public List<E_Commerce_Platform.DataBase.Models.Color>? NewColors { get; set; }
        public List<Size>? NewSizes { get; set; }
        public List<E_Commerce_Platform.DataBase.Models.Category>? NewCategories { get; set; }
    }
}
