namespace AfaqMall.Models
{
    public class Review
    {
        public int Id { get; set; }
        public required Product Product { get; set; }
        public required string Comment { get; set; }
        public int Rating { get; set; } // نجوم التقييم
    }
}
