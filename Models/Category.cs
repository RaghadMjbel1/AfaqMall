namespace AfaqMall.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // قائمة المنتجات
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
