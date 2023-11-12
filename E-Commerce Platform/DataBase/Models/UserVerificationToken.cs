namespace E_Commerce_Platform.DataBase.Models
{
    public class UserVerificationToken
    {
        public int ID { get; set; } 
        public string Token { get; set; } 
        public DateTime ExpireDate { get; set; }    
        public DateTime CreatedAt { get; set; } 
        public User User { get; set; }
        public int UserID { get; set; } 
    }
}
