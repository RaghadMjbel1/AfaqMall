using Microsoft.AspNetCore.Mvc;
using AfaqMall.Data;
using AfaqMall.Models;
using System.Collections.Generic;
using System.Linq;

namespace AfaqMall.Controllers
{
    public class CartController : Controller
    {
        private static List<CartItem> Cart = new List<CartItem>();
        private readonly List<Category> _categories;

        public CartController()
        {
            _categories = SeedData.GetCategories();
        }

        public IActionResult Index()
        {
            return View(Cart);
        }

        public IActionResult AddToCart(int categoryId, int productIndex)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);
            var product = category?.Products[productIndex];
            if (product != null)
            {
                Cart.Add(new CartItem
                {
                    UserId = "demo_user",
                    Product = product,
                    Quantity = 1
                });
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
