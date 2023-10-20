using E_Commerce_Platform.Areas.Admin.ViewModels;
using E_Commerce_Platform.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Commerce_Platform.Areas.Admin.Controllers
{
    [Route("admin/products")]
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly ECommerceDBContext _DBContext;
        public ProductController(ECommerceDBContext dBContext)
        {
            _DBContext = dBContext;
        }
        [HttpGet("add")]
        public IActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Categories = _DBContext.Categories.ToList(),
                Sizes = _DBContext.Sizes.ToList(),
                Colors = _DBContext.Colors.ToList(),
            };

            return View(model);
        }
        [HttpPost]  
        public IActionResult Add(ProductAddViewModel viewModel)
        {

           return RedirectToAction("Index", "Dashboard");
        }
    }
}
