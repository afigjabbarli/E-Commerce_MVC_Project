using E_Commerce_Platform.Constants;

namespace E_Commerce_Platform.DataBase.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; } 
        public string Email { get; set; }
        public string EmailPassword { get; set; }   
        public string PIN { get; set; }
        public string MembershipPassword { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsDeleted { get; set; } 
        public bool IsFrozen { get; set; }
        public Gender Gender { get; set; }  
        public decimal AccountBalance { get; set; }
        public string PhysicalImageName { get; set; }

        public List<Email> Emails { get; set; }

    }
}
