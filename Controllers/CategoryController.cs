using Microsoft.AspNetCore.Mvc;
using AfaqMall.Data;
using AfaqMall.Models;
using System.Linq;
using System.Collections.Generic;

namespace AfaqMall.Controllers
{
    public class CategoryController : Controller
    {
        private readonly List<Category> _categories;

        public CategoryController()
        {
            _categories = SeedData.GetCategories();
        }

        public IActionResult List(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);
        }
    }
}
