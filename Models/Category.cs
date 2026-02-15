using System.Collections.Generic;

namespace AfaqMall.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // إضافة العلاقة مع المنتجات لتوافق Admin Dashboard
        public List<Product>? Products { get; set; }
    }
}
