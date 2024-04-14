using Learnonl.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LearnonlContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("HocOnline"));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie(options =>
    {
        options.LoginPath = "/Authen/Login"; // ???ng d?n ??n trang ??ng nh?p
        options.LogoutPath = "/Authen/Logout"; // ???ng d?n ??n trang ??ng xu?t
        options.Cookie.Name = "Admin";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Th?i gian h?t h?n c?a cookie
        options.SlidingExpiration = true; // Cho ph?p c?p nh?t l?i th?i gian h?t h?n khi c? ho?t ??ng
        options.Cookie.HttpOnly = true; // Ch? s? d?ng HTTP ?? truy c?p cookie
        options.Cookie.IsEssential = true; // X?c ??nh cookie l? c?n thi?t cho vi?c x?c th?c
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Ch?nh s?ch b?o m?t c?a cookie
        options.SlidingExpiration = true; // Cho ph?p c?p nh?t l?i th?i gian h?t h?n khi c? ho?t ??ng
        // C?u h?nh c?c t?y ch?n kh?c t?i ??y

    });

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseCertificateForwarding();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authen}/{action=Login}/{id?}");

app.Run();
