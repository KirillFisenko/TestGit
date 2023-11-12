using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Localization;
using System.Globalization;

using ClassLibrary;

// �������� ������ ���������� web application builder
var builder = WebApplication.CreateBuilder(args);



// ���������� ������������ � ��������������� � ��������� ��������
builder.Services.AddControllersWithViews();





// ��������� ���������� ����������� ��������
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



// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("online_shop");

// ��������� �������� DatabaseContext � �������� ������� � ����������
builder.Services.AddDbContext<ExampleDbContext>(options => options.UseSqlServer(connection));



builder.Services.AddHttpContextAccessor();

// ��������� cookie
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

// �������� ���������� ����������
var app = builder.Build();

// ���� ���������� �� ��������� � ������ ����������
if (!app.Environment.IsDevelopment())
{
    // ����������� ����������� ����������
    app.UseExceptionHandler("/Home/Error");

    // ����������� HSTS
    app.UseHsts();
}

// ����������� ����������� ��������
app.UseRequestLocalization();



// ����������� ����������� ������
app.UseStaticFiles(new StaticFileOptions()
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Add("Cache-Control", "public,max-age=600");
    }
});

// ����������� �������������
app.UseRouting();

// ����������� ��������������
app.UseAuthentication();

// ����������� �����������
app.UseAuthorization();



// ����������� �������� �� ���������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



// ������ ����������
app.Run();