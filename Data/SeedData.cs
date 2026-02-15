using AfaqMall.Models;

namespace AfaqMall.Data
{
    public static class SeedData
    {
        public static List<Category> GetCategories()
        {
            var categories = new List<Category>
            {
                new Category { Id=1, Name="ملابس", Products = GenerateProducts("ملابس") },
                new Category { Id=2, Name="أحذية", Products = GenerateProducts("أحذية") },
                new Category { Id=3, Name="حقائب", Products = GenerateProducts("حقائب") },
                new Category { Id=4, Name="ميك أب", Products = GenerateProducts("ميك أب") }
            };

            return categories;
        }

        private static List<Product> GenerateProducts(string category)
        {
            var list = new List<Product>();
            for (int i = 1; i <= 30; i++)
            {
                list.Add(new Product
                {
                    Name = $"{category} تجريبي {i}",
                    Price = 10 + i,
                    Rating = (i % 5) + 1,
                    ImageUrl = $"https://picsum.photos/300/300?random={i}"
                });
            }
            return list;
        }
    }
}
