namespace AfaqMall.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public required Product Product { get; set; }

        // إضافات للتوافق مع CartController القديم
        public int? ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
