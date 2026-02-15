namespace AfaqMall.Models
{
    public class CartItem
    {
        public int Id { get; set; } // معرف عنصر السلة
        public string UserId { get; set; } // معرف المستخدم الذي أضاف المنتج
        public int ProductId { get; set; } // معرف المنتج
        public Product Product { get; set; } // الربط مع المنتج
        public int Quantity { get; set; } // كمية المنتج المطلوبة
    }
}
