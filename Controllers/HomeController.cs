using Microsoft.AspNetCore.Mvc;
using AfaqMall.Data;
using AfaqMall.Models;
using System.Collections.Generic;

namespace AfaqMall.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<Category> _categories;

        public HomeController()
        {
            _categories = SeedData.GetCategories();
        }

        public IActionResult Index()
        {
            return View(_categories);
        }
    }
}
