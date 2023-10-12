using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]   
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
