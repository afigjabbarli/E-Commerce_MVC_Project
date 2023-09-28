using E_Commerce_Platform.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]   
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserAddViewModel model)
        {
            return View();  
        }
    }
}
