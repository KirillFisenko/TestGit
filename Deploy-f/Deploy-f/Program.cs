using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Localization;
using System.Globalization;

using ClassLibrary;

// создание нового экземпляра web application builder
var builder = WebApplication.CreateBuilder(args);



// добавление контроллеров с представлениями в коллекцию сервисов
builder.Services.AddControllersWithViews();





// настройка параметров локализации запросов
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US")
    };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});



// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("online_shop");

// добавляем контекст DatabaseContext в качестве сервиса в приложение
builder.Services.AddDbContext<ExampleDbContext>(options => options.UseSqlServer(connection));



builder.Services.AddHttpContextAccessor();

// настройка cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.Cookie = new CookieBuilder
    {
        IsEssential = true
    };
});

// создание экземпляра приложения
var app = builder.Build();

// если приложение не находится в режиме разработки
if (!app.Environment.IsDevelopment())
{
    // подключение обработчика исключений
    app.UseExceptionHandler("/Home/Error");

    // подключение HSTS
    app.UseHsts();
}

// подключение локализации запросов
app.UseRequestLocalization();



// подключение статических файлов
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
    }
});

// подключение маршрутизации
app.UseRouting();

// подключение аутентификации
app.UseAuthentication();

// подключение авторизации
app.UseAuthorization();



// определение маршрута по умолчанию
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



// запуск приложения
app.Run();