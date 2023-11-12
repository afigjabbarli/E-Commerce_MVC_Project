using BCrypt.Net;
using E_Commerce_Platform.DataBase;
using E_Commerce_Platform.DataBase.Models;
using E_Commerce_Platform.Services.Abstracts;
using E_Commerce_Platform.Services.Concretes;
using E_Commerce_Platform.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform.Controllers
{
    public class AuthController : Controller
    {
        private readonly ECommerceDBContext _dbContext;
        private readonly VerificationService _verificationService;
        private readonly IFileService _fileService;
        public AuthController(ECommerceDBContext dbContext, VerificationService verificationService, IFileService fileService)
        {
            _dbContext = dbContext;
            _verificationService = verificationService;
            _fileService = fileService;
        }
        [HttpGet]   
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if(_dbContext.Users.Any(u => u.Email == model.Email))
            {
                TempData["ErrorMessage"] = "This email address is already available in the system!!!";
                return RedirectToAction("ErrorPage", "Auth");
            }
            if(_dbContext.Users.Any(u => u.PIN.Equals(model.PIN)))
            {
                TempData["ErrorMessage"] = "This personal identification number is already available in the system!!!";
                return RedirectToAction("ErrorPage", "Auth");
            }
            User user = new User()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                EmailPassword = BCrypt.Net.BCrypt.HashPassword(model.EmailPassword),
                Gender = model.Gender,
                AccountBalance = model.AccountBalance,  
                MembershipPassword = _verificationService.GenerateMembershipPassword(),
                DateofBirth = model.DateofBirth,
                PIN = model.PIN,
                CreatedAt = DateTime.UtcNow,
                PhysicalImageName = _fileService.Upload(model.Image, Contracts.CustomUploadDirectories.Users)
            };
            UserVerificationToken userVerificationToken = new UserVerificationToken
            {
                CreatedAt = DateTime.UtcNow,
                ExpireDate = DateTime.UtcNow.AddHours(2),
                Token = _verificationService.GenerateRandomVerificationToken(),
                User = user
            };
            ///Sending user activation token START...
            
            ///Sending user activation token END...
            _dbContext.UserVerificationTokens.Add(userVerificationToken);   
            _dbContext.Users.Add(user); 
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel Model)
        {
            return RedirectToAction("Index", "Home");   
        }
        [HttpGet]
        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
