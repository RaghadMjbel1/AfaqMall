using Microsoft.AspNetCore.Mvc;
using AfaqMall.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace AfaqMall.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // عرض جميع المنتجات لقسم محدد
        public async Task<IActionResult> List(int id)
        {
            // جلب القسم حسب المعرف
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            // جلب المنتجات الخاصة بالقسم
            var products = await _context.Products
                .Where(p => p.CategoryId == id)
                .ToListAsync();

            ViewBag.CategoryName = category.Name;
            return View(products);
        }
    }
}
