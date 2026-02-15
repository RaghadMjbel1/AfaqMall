using Microsoft.AspNetCore.Mvc;
using AfaqMall.Data;
using AfaqMall.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace AfaqMall.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // لوحة تحكم الأدمن - عرض جميع الأقسام والمنتجات
        public async Task<IActionResult> Dashboard()
        {
            var categories = await _context.Categories
                .Include(c => c.Id)
                .ToListAsync();
            return View(categories);
        }

        // إضافة منتج جديد لقسم محدد
        [HttpPost]
        public async Task<IActionResult> AddProduct(int categoryId, string name, decimal price, int stock)
        {
            var product = new Product
            {
                CategoryId = categoryId,
                Name = name,
                Price = price,
                StockQuantity = stock
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Dashboard");
        }

        // تعديل منتج
        [HttpPost]
        public async Task<IActionResult> EditProduct(int productId, string name, decimal price, int stock)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                product.Name = name;
                product.Price = price;
                product.StockQuantity = stock;
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Dashboard");
        }

        // حذف منتج
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Dashboard");
        }
    }
}
