using AfakStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AfakStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories = SeedData.GetSampleCategories();
            return View(categories);
        }
    }
}
