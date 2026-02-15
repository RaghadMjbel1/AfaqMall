using Microsoft.AspNetCore.Mvc;
using AfaqMall.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AfaqMall.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // الصفحة الرئيسية - تعرض المنتجات المميزة
        public async Task<IActionResult> Index()
        {
            // جلب أول 12 منتج بشكل تجريبي من كل الأقسام
            var products = await _context.Products
                .Include(p => p.Category)
                .Take(12)
                .ToListAsync();

            return View(products);
        }
    }
}
