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
        [HttpGet("details/{colorId}")]
        public IActionResult Details([FromRoute] int colorId)
        {
            var color = _dbContext.Colors.SingleOrDefault(c => c.Id == colorId);
            if (color is null) return Json(new { success = false, message = "Invalid data!" });
            var colorDetails = new ColorDetailsViewModel
            {
                Id = color.Id,
                Name = color.Name,
                Code = color.Code,
                CreatedAt = color.CreatedAt,
                UpdatedAt = color.UpdatedAt,
            };
            return Json(new { success = true, colorDetails, message = "Color information found successfully..." });
        }
        [HttpGet("update/{colorId}")]
        public IActionResult Update([FromRoute] int colorId)
        {
            var color = _dbContext.Colors.SingleOrDefault(c => c.Id.Equals(colorId));
            if (color is null) return Json(new { success = false, message = "Invalid data!" });
            else return Json(new { success = true, id = color.Id, code = color.Code, name = color.Name, message = "Color information found successfully..." });
        }
        [HttpPost("update/{colorId}")]
        public IActionResult Update([FromRoute] int colorId, [FromBody] ColorAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                 var color = _dbContext.Colors.SingleOrDefault(c => c.Id.Equals(colorId));
                 if (color is null) return Json(new { success = false, message = "Invalid data...Category not available!" });
                 color.Name = model.colorName;
                 color.Code = model.colorCode;
                 color.UpdatedAt = DateTime.UtcNow;  
                 _dbContext.Colors.Update(color);    
                 _dbContext.SaveChanges();
                 return Json(new { success = true, id = color.Id, name = color.Name, code = color.Code });

            }
            return Json(new { success = false, message = "Invalid data." });
        }    
    }
}
