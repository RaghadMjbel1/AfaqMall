namespace AfakStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public bool IsFavorite { get; set; }
        public int CategoryId { get; set; }
    }
}
