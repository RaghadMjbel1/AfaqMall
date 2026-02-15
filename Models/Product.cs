namespace AfaqMall.Models
{
    public class Product
    {
        public int Id { get; set; } // معرف المنتج
        public string Name { get; set; } // اسم المنتج
        public decimal Price { get; set; } // سعر المنتج
        public int StockQuantity { get; set; } // كمية المخزون
        public int CategoryId { get; set; } // معرف القسم الذي ينتمي إليه المنتج
        public Category Category { get; set; } // الربط مع قسم المنتج

        // يمكنك لاحقاً إضافة تقييمات المنتجات أو خصائص إضافية
        // مثل صورة المنتج أو وصف
    }
}
