using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform.Controllers
{
    [Authorize]
    public class EmailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Sent()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Send(UserController user)
        {
            return View();
        }
        [HttpGet]   
        public IActionResult Trash()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
    }
}
