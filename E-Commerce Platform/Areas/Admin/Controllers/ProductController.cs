using E_Commerce_Platform.Areas.Admin.ViewModels.Product;
using E_Commerce_Platform.Contracts;
using E_Commerce_Platform.DataBase;
using E_Commerce_Platform.DataBase.Models;
using E_Commerce_Platform.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

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

            if (viewModel.Image is not null)
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
                if (size is null)
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
                if (color is null)
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
            return RedirectToAction(nameof(Read));
        }
        [HttpGet("read")]
        public IActionResult Read()
        {
            var products = _DBContext.Products.OrderBy(p => p.CreatedAt).ToList();
            var productList = ConvertProductsToViewModel(products);
            return View(productList);
        }
        public List<ProductListItemViewModel> ConvertProductsToViewModel(List<Product> products)
        {
            List<ProductListItemViewModel> viewModels = new List<ProductListItemViewModel>();

            foreach (var product in products)
            {
                ProductListItemViewModel viewModel = new ProductListItemViewModel
                {
                    ID = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImageUrl = _fileService.GetStaticFilesUrl(CustomUploadDirectories.Products, product.PhysicalImageName),
                    Colors = _DBContext.ProductColors.Where(pc => pc.ProductId == product.Id).Select(pc => pc.Color).ToList(),
                    Sizes = _DBContext.ProductSizes.Where(ps => ps.ProductId == product.Id).Select(ps => ps.Size).ToList(),
                    Categories = _DBContext.CategoryProducts.Where(cp => cp.ProductId == product.Id).Select(cp => cp.Category).ToList(),
                };

                viewModels.Add(viewModel);
            }

            return viewModels;
        }
        [HttpGet("{id}/update")]
        public IActionResult Update(int id)
        {
            var product = _DBContext.Products.SingleOrDefault(p => p.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            var colors = _DBContext.ProductColors.Where(pc => pc.ProductId == product.Id).Select(product => product.Color).ToList();
            var sizes = _DBContext.ProductSizes.Where(ps => ps.ProductId == product.Id).Select(product => product.Size).ToList();
            var categories = _DBContext.CategoryProducts.Where(cp => cp.ProductId == product.Id).Select(product => product.Category).ToList();
            var model = new ProductUpdateViewModel
            {
                Colors = colors,
                Sizes = sizes,
                Categories = categories,
                ProductId = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = _fileService.GetStaticFilesUrl(CustomUploadDirectories.Products, product.PhysicalImageName),
                NewColors = _DBContext.Colors.ToList(),
                NewSizes = _DBContext.Sizes.ToList(),
                NewCategories = _DBContext.Categories.ToList()
            };
            return View(model);
        }
        //[HttpPost("update")]
        //public IActionResult Update(ProductAddViewModel model)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
                
        //    var product = _DBContext.Products.SingleOrDefault(p => p.Id == model.ProductId);    
        //    if(product is null)
        //    {
        //        return NotFound();
        //    }
        //    if(model.Image is not null)
        //    {
        //        product.PhysicalImageName = _fileService.Upload(model.Image, CustomUploadDirectories.Products); ;   
        //    }
        //    product.Name = model.Name;
        //    product.Description = model.Description;    
        //    product.Price = model.Price;    
        //    product.UpdatedAt = DateTime.UtcNow;

        //    #region Color Addition

        //    foreach (var colorID in model.ColorIds)
        //    {
        //        var color = _DBContext.Colors.SingleOrDefault(c => c.Id == colorID);
        //        if(color is null)
        //        {
        //            var colors = _DBContext.Colors.ToList();
        //            ModelState.AddModelError("ColorIds", "Color not found");
        //            return View(colors);
        //        }
        //        var productColor = new ProductColor
        //        {
        //            ColorId = color.Id,
        //            ProductId = product.Id,
        //        };
        //        _DBContext.ProductColors.Add(productColor); 
        //    }

        //    #endregion

        //    #region Size Addition

        //    foreach (var sizeID in model.SizeIds)
        //    {
        //        var size = _DBContext.Sizes.SingleOrDefault(s => s.Id == sizeID);
        //        if(size is null)
        //        {
        //            var sizes = _DBContext.Sizes.ToList();
        //            ModelState.AddModelError("SizeIds", "Szie not found");
        //            return View(sizes);
        //        }
        //        var productSize = new ProductSize
        //        {
        //            SizeId = size.Id,
        //            ProductId = product.Id
        //        };
        //        _DBContext.ProductSizes.Add(productSize);   
        //    }

        //    #endregion


        //    #region Category Addition

        //    foreach(var categoryID in model.CategoryIds)
        //    {
        //        var category = _DBContext.Categories.SingleOrDefault(ct => ct.Id == categoryID);
        //        if (category is null)
        //        {
        //            var categories = _DBContext.Categories.ToList();
        //            ModelState.AddModelError("CategoryIds", "Category not found");
        //            return View(categories);
        //        }
        //        var categoryProduct = new CategoryProduct
        //        {
        //            CategoryId = category.Id,
        //            ProductId = product.Id
        //        };

        //        _DBContext.CategoryProducts.Add(categoryProduct);   
        //    }

        //    #endregion

        //    return View();
        //}
        [HttpPost("{id}/delete")]
        public IActionResult Delete(int id)
        {
            var product = _DBContext.Products.Where(product => product.Id == id).SingleOrDefault();
            if (product is null)
            {
                return NotFound();
            }
            _DBContext.Products.Remove(product);
            _DBContext.SaveChanges();
            return RedirectToAction(nameof(Read));
        }
    }
}
