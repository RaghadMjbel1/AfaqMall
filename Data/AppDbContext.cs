using Microsoft.EntityFrameworkCore;
using AfaqMall.Models;

namespace AfaqMall.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } // الأقسام
        public DbSet<Product> Products { get; set; } // المنتجات
        public DbSet<CartItem> CartItems { get; set; } // عناصر السلة
        public DbSet<Order> Orders { get; set; } // الطلبات
        public DbSet<Review> Reviews { get; set; } // التقييمات
    }
}
