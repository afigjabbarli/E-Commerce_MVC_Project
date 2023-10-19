namespace E_Commerce_Platform.DataBase.Models
{
    public class ProductSize
    {
        public Product Product { get; set; }    
        public int ProductId { get; set; }  
        public Size Size { get; set; }
        public int SizeId { get; set; } 
    }
}
