using AfaqMall.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AfaqMall.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // إذا كان هناك أقسام بالفعل، لا نفعل شيء
            if (context.Categories.Any())
                return;

            // إنشاء الأقسام الأربعة
            var categories = new Category[]
            {
                new Category { Name = "Clothes" },
                new Category { Name = "Shoes" },
                new Category { Name = "Bags" },
                new Category { Name = "Makeup" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            // لكل قسم، إنشاء 30 منتج تجريبي
            foreach (var cat in categories)
            {
                for (int i = 1; i <= 30; i++)
                {
                    context.Products.Add(new Product
                    {
                        Name = $"{cat.Name} Product {i}",
                        Price = 10 + i, // أسعار تجريبية
                        StockQuantity = 50, // كمية تجريبية
                        CategoryId = cat.Id
                    });
                }
            }

            context.SaveChanges();
        }
    }
}
