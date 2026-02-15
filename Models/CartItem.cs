namespace AfaqMall.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public required string UserId { get; set; }

        // لإبقاء CartController القديم يعمل
        public required Product Product { get; set; }
        public int? ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
