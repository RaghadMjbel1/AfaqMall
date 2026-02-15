using System;

namespace AfaqMall.Models
{
    public class Order
    {
        public int Id { get; set; } // معرف الطلب
        public string FullName { get; set; } // اسم العميل
        public string PhoneNumber { get; set; } // رقم الهاتف
        public string Address { get; set; } // عنوان العميل
        public string PaymentCode { get; set; } // كود الدفع (مثلاً شام كاش)
        public decimal TotalAmount { get; set; } // إجمالي سعر الطلب
        public bool IsPaid { get; set; } // حالة الدفع
        public DateTime CreatedAt { get; set; } // تاريخ إنشاء الطلب
    }
}
