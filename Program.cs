using AfaqMall.Data;
using AfaqMall.Services;

var builder = WebApplication.CreateBuilder(args);

// إضافة الخدمات العادية
builder.Services.AddControllersWithViews();

// استدعاء SeedData.Initialize() لتجنب CS0117
SeedData.Initialize();

// إعداد TelegramService مع قيم فارغة لتجنب التحذيرات
string botToken = Environment.GetEnvironmentVariable("TELEGRAM_BOT_TOKEN") ?? "";
string chatId = Environment.GetEnvironmentVariable("TELEGRAM_CHAT_ID") ?? "";
var telegramService = new TelegramService(botToken, chatId);

var app = builder.Build();

// إعداد الـ Middleware المعتاد
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
