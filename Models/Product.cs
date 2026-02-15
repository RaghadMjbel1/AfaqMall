namespace AfaqMall.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }

        // استرجاع CategoryId القديم للتوافق مع SeedData و Controllers
        public int? CategoryId { get; set; } // nullable لتجنب مشاكل الربط القديم
        public required string Category { get; set; }

        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
    }
}
