using E_Commerce_Platform.Areas.Admin.ViewModels;
using E_Commerce_Platform.Contracts;
using E_Commerce_Platform.DataBase;
using E_Commerce_Platform.DataBase.Models;
using E_Commerce_Platform.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace E_Commerce_Platform.Areas.Admin.Controllers
{
    [Route("admin/products")]
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly ECommerceDBContext _DBContext;
        private readonly IFileService _fileService;
        public ProductController(ECommerceDBContext dBContext, IFileService fileService)
        {
            _DBContext = dBContext;
            _fileService = fileService;
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
        [HttpPost("add")]
        public IActionResult Add(ProductAddViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var model = new ProductAddViewModel
                {
                    Categories = _DBContext.Categories.ToList(),
                    Sizes = _DBContext.Sizes.ToList(),
                    Colors = _DBContext.Colors.ToList(),
                };   
                return View(model); 
            }
           
            Product newProduct = new Product
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };

            if(viewModel.Image is not null)
            {
                newProduct.PhysicalImageName = _fileService
                    .Upload(viewModel.Image, CustomUploadDirectories.Products);
            }
                
            _DBContext.Products.Add(newProduct);
            ///Category start...
            foreach (var categoryID in viewModel.CategoryIds)
            {
                var category = _DBContext.Categories.SingleOrDefault(c => c.Id == categoryID);
                if (category is null)
                {
                    var categories = _DBContext.Categories.ToList();
                    ModelState.AddModelError("CategoryIds", "Category not found");
                    return View(categories);
                }
                var categoryProduct = new CategoryProduct
                {
                    CategoryId = category.Id,
                    Product = newProduct
                };
                _DBContext.CategoryProducts.Add(categoryProduct);   
            }
            ///Category end...
            ///
            ///Size  start...
            foreach (var sizeID in viewModel.SizeIds)
            {
                var size = _DBContext.Sizes.SingleOrDefault(s => s.Id == sizeID);
                if(size is null)
                {
                    var sizes = _DBContext.Sizes.ToList();
                    ModelState.AddModelError("SizeIds", "Size not found");
                    return View(sizes);
                }
                var productSize = new ProductSize
                {
                    SizeId = size.Id,
                    Product = newProduct
                };
                _DBContext.ProductSizes.Add(productSize);
            }
            ///Size  end...
            ///
            ///Color start...
            foreach (var colorID in viewModel.ColorIds)
            {
                var color = _DBContext.Colors.SingleOrDefault(c => c.Id == colorID);
                if(color is null)
                {
                    var colors = _DBContext.Colors.ToList();
                    ModelState.AddModelError("ColorIds", "Color not found");
                    return View(colors);    
                }
                var productColor = new ProductColor
                {
                    ColorId = color.Id,
                    Product = newProduct
                };
                _DBContext.ProductColors.Add(productColor); 
            }
            ///Color end...
            _DBContext.SaveChanges();   
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
