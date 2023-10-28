using E_Commerce_Platform.Areas.Admin.ViewModels.Category;
using E_Commerce_Platform.DataBase;
using E_Commerce_Platform.DataBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Platform.Areas.Admin.Controllers
{
    [Route("admin/categories")]
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly ECommerceDBContext _dbContext;
        public CategoryController(ECommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("read")]
        public IActionResult Read()
        {
            var allCategories = _dbContext.Categories
                .Select(c => new CategoryListItemViewModel { Description = c.Description, Name = c.Name, Id = c.Id})
                .ToList();
                
            return View(allCategories);
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] CategoryAddViewModel category)
        {
            if (ModelState.IsValid)
            {
                // Assuming you have a Category model, create an instance and populate it
                var newCategory = new Category
                {
                    Name = category.Name,
                    Description = category.Description,
                    CreatedAt = DateTime.UtcNow,   
                    UpdatedAt = DateTime.UtcNow,
                };

                // Add the new category to your database
                _dbContext.Categories.Add(newCategory);
                _dbContext.SaveChanges();

                // Return a JSON response to indicate success and provide the new category's ID
                return Json(new { success = true, id = newCategory.Id, name = newCategory.Name, description = newCategory.Description, succesMessage = "New category succesfully added...Thanks:)" });
            }
            else
            {
                // If the ModelState is not valid, return an error response
                return Json(new { success = false, message = "Invalid data." });
            }
        }
        [HttpPost("delete/{categoryId}")]
        public IActionResult Delete([FromRoute] int categoryId)
        {
            var removableCategory = _dbContext.Categories.SingleOrDefault(c => c.Id == categoryId);
            if (removableCategory != null)
            {
                _dbContext.Categories.Remove(removableCategory);
                _dbContext.SaveChanges();
                return Json(new {success = true, message = "The category you selected has been deleted..." });
            }
            else
            {
                // If the ModelState is not valid, return an error response
                return Json(new { success = false, message = "Invalid data." });
            }
        }
        [HttpGet("details/{categoryId}")]
        public IActionResult Details([FromRoute] int categoryId)
        {
            var category = _dbContext.Categories.SingleOrDefault(ct => ct.Id == categoryId);
            if (category != null)
            {
                return Json(new { success = true, Id = category.Id, Name = category.Name, Description = category.Description, CreatedAt = category.CreatedAt, UpdatedAt = category.UpdatedAt, message = "Category information found successfully..." });
            }
            else
            {
                return Json(new { success = false, message = "Invalid data." });
            }
        }

    }
    
}
