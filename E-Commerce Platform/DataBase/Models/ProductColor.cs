namespace E_Commerce_Platform.DataBase.Models
{
    public class ProductColor
    {
        public Product Product { get; set; }    
        public int ProductId { get; set; }  
        public Color Color { get; set; }    
        public int ColorId { get; set; }    
    }
}
