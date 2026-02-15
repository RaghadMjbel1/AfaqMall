using System;
using System.Collections.Generic;

namespace AfaqMall.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required string PaymentCode { get; set; }
        public List<Product>? Products { get; set; }

        // لمزامنة Views و Controllers القديمة
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
