using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform.Areas.Admin.Controllers
{
    [Route("admin/categories")]
    [Area("admin")]
    public class CategoryController : Controller
    {
        [HttpGet("read")]
        public IActionResult Read()
        {
            return View();  
        }
    }
}
