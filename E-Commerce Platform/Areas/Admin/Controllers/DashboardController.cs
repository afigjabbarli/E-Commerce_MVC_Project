using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform.Areas.Admin.Controllers
{
    [Route("admin/dashboard")]
    [Area("admin")]
    public class DashboardController : Controller
    {
        [HttpGet("index")]
        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            return View();
        }
    }
}
