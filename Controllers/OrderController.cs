using Microsoft.AspNetCore.Mvc;
using AfaqMall.Data;
using AfaqMall.Models;
using AfaqMall.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AfaqMall.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly TelegramService _telegramService;

        public OrderController(AppDbContext context, TelegramService telegramService)
        {
            _context = context;
            _telegramService = telegramService;
        }

        // صفحة Checkout
        public async Task<IActionResult> Checkout(string userId)
        {
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return View(cartItems);
        }

        // تأكيد الطلب بعد الدفع
        [HttpPost]
        public async Task<IActionResult> Confirm(string userId, string fullName, string phoneNumber, string address, string paymentCode)
        {
            var cartItems = await _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
                return RedirectToAction("Index", "Cart");

            decimal total = cartItems.Sum(c => c.Product.Price * c.Quantity);

            var order = new Order
            {
                FullName = fullName,
                PhoneNumber = phoneNumber,
                Address = address,
                PaymentCode = paymentCode,
                TotalAmount = total,
                IsPaid = true, // بعد تأكيد الدفع
                CreatedAt = System.DateTime.Now
            };

            _context.Orders.Add(order);

            // حذف العناصر من السلة بعد تأكيد الطلب
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            // إرسال إشعار إلى Telegram (يمكن تعديل الصورة لاحقاً)
            string message = $"New Order:\nName: {fullName}\nPhone: {phoneNumber}\nTotal: {total}";
            byte[] dummyImage = new byte[0]; // لاحقاً نضع صورة الطلب
            await _telegramService.SendOrderNotificationAsImage(message, dummyImage);

            return View("OrderConfirmed", order);
        }
    }
}
