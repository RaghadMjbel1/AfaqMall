using AfaqMall.Models;
using System;
using System.Collections.Generic;

namespace AfaqMall.Data
{
    public static class SeedData
    {
        public static void Initialize()
        {
            var categories = GetCategories();
        }

        public static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "ملابس", Products = new List<Product>() },
                new Category { Id = 2, Name = "أحذية", Products = new List<Product>() },
                new Category { Id = 3, Name = "حقائب", Products = new List<Product>() },
                new Category { Id = 4, Name = "ميك أب", Products = new List<Product>() }
            };

            foreach (var category in categories)
            {
                for (int i = 1; i <= 30; i++)
                {
                    var product = new Product
                    {
                        Name = $"{category.Name} منتج {i}",
                        Price = 10 + i,
                        StockQuantity = 50,
                        Category = category.Name,
                        CategoryId = category.Id,
                        Rating = new Random().Next(3, 6), // 3-5 نجوم
                        ImageUrl = $"https://picsum.photos/seed/{category.Name.ToLower()}{i}/200/200",
                        IsFavorite = false
                    };
                    category.Products.Add(product);
                }
            }

            return categories;
        }
    }
}
