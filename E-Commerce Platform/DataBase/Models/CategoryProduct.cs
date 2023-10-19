namespace E_Commerce_Platform.DataBase.Models
{
    public class CategoryProduct
    {
        public Category Category { get; set; }  
        public int CategoryId { get; set; } 
        public Product Product { get; set; }
        public int ProductId { get; set; }
        
    }
}
