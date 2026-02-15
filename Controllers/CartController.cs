using Microsoft.AspNetCore.Mvc;
using AfaqMall.Models;
using AfaqMall.Data;
using System.Linq;
using System.Collections.Generic;

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

        [HttpPost]
        public IActionResult AddToCart(int categoryId, int productIndex)
        {
            var category = _categories.FirstOrDefault(c => c.Id == categoryId);
            var product = category?.Products?[productIndex];
            if (product != null)
            {
                var cartItem = new CartItem
                {
                    UserId = "demo_user",
                    Product = product, // required
                    ProductId = product.Id,
                    Quantity = 1
                };
                Cart.Add(cartItem);
            }
            return RedirectToAction("Index");
        }
    }
}
