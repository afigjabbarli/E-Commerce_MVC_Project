namespace E_Commerce_Platform.DataBase.Models
{
    public class Email
    {
        public int Id { get; set; } 
        public string Sender { get; set; }  
        public string[] Recipients { get; set; }    
        public string Subject { get; set; } 
        public string Content { get; set; }    
        public bool IsRead { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? ReadDate { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }  
    }
}
