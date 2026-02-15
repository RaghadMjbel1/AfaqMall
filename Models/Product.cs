namespace AfaqMall.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public required string Category { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        public int Rating { get; set; }
        public bool IsFavorite { get; set; }
    }
}
