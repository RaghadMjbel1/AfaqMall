using Microsoft.AspNetCore.Mvc;
using AfaqMall.Models;
using System.Collections.Generic;

namespace AfaqMall.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>();

            // أسماء الأقسام
            string[] categories = { "Clothes", "Shoes", "Bags", "Makeup" };

            // روابط صور مجانية لكل قسم (يمكنك تعديلها لاحقًا)
            var imageLinks = new Dictionary<string, string[]>()
            {
                { "Clothes", new string[]
                    {
                        "https://picsum.photos/seed/clothes1/200/200",
                        "https://picsum.photos/seed/clothes2/200/200",
                        "https://picsum.photos/seed/clothes3/200/200",
                        "https://picsum.photos/seed/clothes4/200/200",
                        "https://picsum.photos/seed/clothes5/200/200"
                    }
                },
                { "Shoes", new string[]
                    {
                        "https://picsum.photos/seed/shoes1/200/200",
                        "https://picsum.photos/seed/shoes2/200/200",
                        "https://picsum.photos/seed/shoes3/200/200",
                        "https://picsum.photos/seed/shoes4/200/200",
                        "https://picsum.photos/seed/shoes5/200/200"
                    }
                },
                { "Bags", new string[]
                    {
                        "https://picsum.photos/seed/bags1/200/200",
                        "https://picsum.photos/seed/bags2/200/200",
                        "https://picsum.photos/seed/bags3/200/200",
                        "https://picsum.photos/seed/bags4/200/200",
                        "https://picsum.photos/seed/bags5/200/200"
                    }
                },
                { "Makeup", new string[]
                    {
                        "https://picsum.photos/seed/makeup1/200/200",
                        "https://picsum.photos/seed/makeup2/200/200",
                        "https://picsum.photos/seed/makeup3/200/200",
                        "https://picsum.photos/seed/makeup4/200/200",
                        "https://picsum.photos/seed/makeup5/200/200"
                    }
                }
            };

            foreach (var cat in categories)
            {
                for (int i = 1; i <= 30; i++)
                {
                    // اختيار صورة عشوائية من 5 صور لكل قسم
                    var imgArray = imageLinks[cat];
                    string imageUrl = imgArray[(i - 1) % imgArray.Length];

                    products.Add(new Product
                    {
                        Name = $"{cat} Product {i}",
                        Price = 10 + i, // سعر تجريبي
                        Category = cat,
                        StockQuantity = 50,
                        ImageUrl = imageUrl
                    });
                }
            }

            return View(products);
        }
    }
}
