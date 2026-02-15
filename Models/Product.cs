namespace AfaqMall.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Category { get; set; } // القسم
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; } // nullable لتجنب التحذير
    }
}
