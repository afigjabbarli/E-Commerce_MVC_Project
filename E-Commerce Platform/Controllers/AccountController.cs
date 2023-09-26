using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]   
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
