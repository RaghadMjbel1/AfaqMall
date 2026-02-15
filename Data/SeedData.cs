using AfaqMall.Models;
using System;
using System.Collections.Generic;

namespace AfaqMall.Data
{
    public static class SeedData
    {
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
                    category.Products.Add(new Product
                    {
                        Name = $"{category.Name} منتج {i}",
                        Price = Math.Round(10 + new Random().NextDouble() * 90, 2),
                        Rating = new Random().Next(3, 6),
                        ImageUrl = $"https://picsum.photos/seed/{category.Name.ToLower()}{i}/300/300",
                        Category = category.Name,
                        CategoryId = category.Id,
                        IsFavorite = false
                    });
                }
            }
            return categories;
        }
    }
}
