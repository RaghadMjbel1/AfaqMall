using Microsoft.AspNetCore.Mvc;
using AfaqMall.Data;
using AfaqMall.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace AfaqMall.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        // عرض محتوى السلة
        public async Task<IActionResult> Index(string userId)
        {
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return View(cartItems);
        }

        // إضافة منتج إلى السلة
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity, string userId)
        {
            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserId == userId);

            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
                _context.CartItems.Update(cartItem);
            }
            else
            {
                _context.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    UserId = userId
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // إزالة منتج من السلة
        [HttpPost]
        public async Task<IActionResult> Remove(int cartItemId)
        {
            var item = await _context.CartItems.FindAsync(cartItemId);
            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
