namespace AfaqMall.Models
{
    public class Review
    {
        public int Id { get; set; } // معرف التقييم
        public int ProductId { get; set; } // معرف المنتج الذي تم تقييمه
        public Product Product { get; set; } // الربط مع المنتج
        public int Rating { get; set; } // التقييم من 1 إلى 5 نجوم
        public string Comment { get; set; } // تعليق العميل على المنتج
    }
}
