using Microsoft.AspNetCore.Mvc;
using AfaqMall.Models;
using AfaqMall.Data;
using System.Linq;

namespace AfaqMall.Controllers
{
    public class AdminController : Controller
    {
        private readonly List<Category> _categories;

        public AdminController()
        {
            _categories = SeedData.GetCategories();
        }

        public IActionResult Dashboard()
        {
            return View(_categories);
        }

        [HttpPost]
        public IActionResult AddProduct(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                var product = new Product
                {
                    Name = $"New Product {category.Products?.Count + 1 ?? 1}",
                    Price = 20,
                    StockQuantity = 50,
                    Category = category.Name, // required
                    CategoryId = category.Id,
                    ImageUrl = "https://picsum.photos/200/200"
                };
                category.Products?.Add(product);
            }
            return RedirectToAction("Dashboard");
        }
    }
}
