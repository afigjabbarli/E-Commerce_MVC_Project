using E_Commerce_Platform.DataBase.Models;

namespace E_Commerce_Platform.Areas.Admin.ViewModels.Product
{
    public class ProductListItemViewModel
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public List<E_Commerce_Platform.DataBase.Models.Color> Colors { get; set; } 
        public List<Size> Sizes { get; set; }   
        public List<E_Commerce_Platform.DataBase.Models.Category> Categories { get; set; }  
    }
}
