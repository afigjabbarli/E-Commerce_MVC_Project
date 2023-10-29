using E_Commerce_Platform.Areas.Admin.ViewModels.Color;
using E_Commerce_Platform.DataBase;
using E_Commerce_Platform.DataBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform.Areas.Admin.Controllers
{

    [Route("admin/colors")]
    [Area("admin")]
    public class ColorController : Controller
    {
        private readonly ECommerceDBContext _dbContext;
        public ColorController(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("read")]
        public ActionResult Read()
        {
            var colors = _dbContext.Colors
                .Select(c => new ColorListItemViewModel { Id = c.Id, Name = c.Name, Code = c.Code })
                .ToList();
            return View(colors);
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] ColorAddViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid data!" });
            }
            Color color = new Color
            {
                Name = model.colorName,
                Code = model.colorCode,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            _dbContext.Colors.Add(color);
            _dbContext.SaveChanges();
            return Json(new { success = true, id = color.Id, name = color.Name, code = color.Code, succesMessage = "New color succesfully added...Thanks:)" });
        }
        [HttpDelete("delete/{colorId}")]  
        public IActionResult Delete([FromRoute] int colorId)
        {
            var removableColor = _dbContext.Colors.SingleOrDefault(c => c.Id == colorId);
            if(removableColor is null) return Json(new { success = false, message = "Invalid data!" });
            _dbContext.Colors.Remove(removableColor);    
            _dbContext.SaveChanges();
            return Json(new { success = true, id = removableColor.Id });
        }
    }
}
