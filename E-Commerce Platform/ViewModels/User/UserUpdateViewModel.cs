using E_Commerce_Platform.Constants;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace E_Commerce_Platform.ViewModels.User
{
    public class UserUpdateViewModel
    {
        
        public string Name { get; set; }

       
        public string Surname { get; set; }

      
        public string Email { get; set; }

      
        public string EmailPassword { get; set; }

       
        public string PIN { get; set; }

       
        public DateTime DateofBirth { get; set; }

       
        public Gender Gender { get; set; }

     
        public decimal AccountBalance { get; set; }

       
        public string PhysicalImageName { get; set; }
    }
}
