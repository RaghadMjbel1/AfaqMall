using AfaqMall.Models;
using System.Collections.Generic;

namespace AfaqMall.Data
{
    public static class SeedData
    {
        public static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Clothes", Products = new List<Product>() },
                new Category { Id = 2, Name = "Shoes", Products = new List<Product>() },
                new Category { Id = 3, Name = "Bags", Products = new List<Product>() },
                new Category { Id = 4, Name = "Makeup", Products = new List<Product>() }
            };

            foreach (var category in categories)
            {
                for (int i = 1; i <= 30; i++)
                {
                    var product = new Product
                    {
                        Name = $"{category.Name} Product {i}",
                        Price = 10 + i,
                        StockQuantity = 50,
                        Category = category.Name, // required
                        CategoryId = category.Id,
                        ImageUrl = $"https://picsum.photos/seed/{category.Name.ToLower()}{i}/200/200"
                    };
                    category.Products?.Add(product);
                }
            }

            return categories;
        }
    }
}
