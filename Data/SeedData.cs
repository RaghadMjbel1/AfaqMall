using AfakStore.Models;
using System.Collections.Generic;

namespace AfakStore
{
    public static class SeedData
    {
        public static List<Category> GetSampleCategories()
        {
            var categories = new List<Category>();

            // الملابس
            var clothes = new Category { Id = 1, Name = "ملابس" };
            for (int i = 1; i <= 10; i++)
            {
                clothes.Products.Add(new Product
                {
                    Id = i,
                    Name = $"ملابس رقم {i}",
                    Price = 50 + i * 10,
                    Rating = (i % 5) + 1,
                    IsFavorite = i % 2 == 0,
                    ImageUrl = "/images/tshirt.jpg",
                    CategoryId = 1
                });
            }
            categories.Add(clothes);

            // الأحذية
            var shoes = new Category { Id = 2, Name = "أحذية" };
            for (int i = 1; i <= 10; i++)
            {
                shoes.Products.Add(new Product
                {
                    Id = 100 + i,
                    Name = $"حذاء رقم {i}",
                    Price = 100 + i * 15,
                    Rating = (i % 5) + 1,
                    IsFavorite = i % 2 == 1,
                    ImageUrl = "/images/shoes.jpg",
                    CategoryId = 2
                });
            }
            categories.Add(shoes);

            // الإلكترونيات
            var electronics = new Category { Id = 3, Name = "إلكترونيات" };
            for (int i = 1; i <= 10; i++)
            {
                electronics.Products.Add(new Product
                {
                    Id = 200 + i,
                    Name = $"جهاز إلكتروني رقم {i}",
                    Price = 200 + i * 25,
                    Rating = (i % 5) + 1,
                    IsFavorite = i % 2 == 0,
                    ImageUrl = "/images/electronic.jpg",
                    CategoryId = 3
                });
            }
            categories.Add(electronics);

            // الميك أب
            var makeup = new Category { Id = 4, Name = "ميك أب" };
            for (int i = 1; i <= 10; i++)
            {
                makeup.Products.Add(new Product
                {
                    Id = 300 + i,
                    Name = $"منتج ميك أب رقم {i}",
                    Price = 40 + i * 12,
                    Rating = (i % 5) + 1,
                    IsFavorite = i % 2 == 1,
                    ImageUrl = "/images/makeup.jpg",
                    CategoryId = 4
                });
            }
            categories.Add(makeup);

            return categories;
        }
    }
}
