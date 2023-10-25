using E_Commerce_Platform.DataBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform.Areas.Admin.Controllers
{
    public class ErrorPagesController : Controller
    {
        [HttpGet]
        public IActionResult NotFoundPage()
        {
            
            Response.StatusCode = 404;
            return View("~/Areas/Admin/Views/ErrorPages/NotFoundPage.cshtml");
        }

        
    }

}
