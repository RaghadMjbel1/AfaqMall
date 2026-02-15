using Microsoft.EntityFrameworkCore;
using AfaqMall.Data;
using AfaqMall.Services;

var builder = WebApplication.CreateBuilder(args);

// إضافة الخدمات
builder.Services.AddControllersWithViews();

// إعداد قاعدة البيانات (SQLite كمثال)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// إعداد خدمة Telegram
builder.Services.AddSingleton<TelegramService>(provider =>
{
    var botToken = builder.Configuration["Telegram:BotToken"];
    var chatId = builder.Configuration["Telegram:ChatId"];
    return new TelegramService(botToken, chatId);
});

var app = builder.Build();

// تهيئة SeedData عند التشغيل لأول مرة
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData.Initialize(dbContext);
}

// إعداد الـ Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// إعداد الـ Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
