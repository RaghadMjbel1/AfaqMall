using AfaqMall.Models;

namespace AfaqMall.Data
{
    public static class SeedData
    {
        public static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "ملابس" },
                new Category { Id = 2, Name = "أحذية" },
                new Category { Id = 3, Name = "حقائب" },
                new Category { Id = 4, Name = "ميك أب" }
            };

            foreach (var category in categories)
            {
                for (int i = 1; i <= 30; i++)
                {
                    category.Products.Add(new Product
                    {
                        Name = $"{category.Name} منتج {i}",
                        Price = 10 + i,
                        Rating = (i % 5) + 1,
                        ImageUrl = $"https://picsum.photos/seed/{category.Name.ToLower()}{i}/300/300"
                    });
                }
            }

            return categories;
        }
    }
}
