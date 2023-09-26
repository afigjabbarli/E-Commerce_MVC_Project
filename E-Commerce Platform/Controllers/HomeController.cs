using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
