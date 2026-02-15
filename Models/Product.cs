namespace AfaqMall.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }  // من 1 إلى 5
        public string ImageUrl { get; set; }
    }
}
