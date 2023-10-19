namespace E_Commerce_Platform.DataBase.Models
{
    public class Color
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<ProductColor> ProductColors { get; set; }   
    }
}
