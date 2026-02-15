using System.Net.Http;
using System.Threading.Tasks;

namespace AfaqMall.Services
{
    public class TelegramService
    {
        private readonly string _botToken; // توكن البوت
        private readonly string _chatId;   // معرف الشات

        public TelegramService(string botToken, string chatId)
        {
            _botToken = botToken;
            _chatId = chatId;
        }

        // إرسال إشعار الطلب مع صورة إلى Telegram
        public async Task SendOrderNotificationAsImage(string message, byte[] imageBytes)
        {
            using var client = new HttpClient();
            var content = new MultipartFormDataContent();
            content.Add(new ByteArrayContent(imageBytes), "photo", "order.png");
            content.Add(new StringContent(_chatId), "chat_id");
            content.Add(new StringContent(message), "caption");

            await client.PostAsync($"https://api.telegram.org/bot{_botToken}/sendPhoto", content);
        }
    }
}
