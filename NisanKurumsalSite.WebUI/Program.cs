using NisanKurumsalSite.Data; // Data katman�n� kullanabilmek i�in
using Microsoft.AspNetCore.Authentication.Cookies; // oturum a�ma k�t�phanesi
using System.Security.Claims; // yetkilendirme k�t�phanesi

namespace NisanKurumsalSite.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DatabaseContext>(); // DatabaseContext
            builder.Services.AddSession(); // Session kullanmak i�in
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/Account/Login";
                x.Cookie.Name = "Account";
                x.Cookie.MaxAge = TimeSpan.FromDays(1); // cookie nin ya�am s�resi
                x.Cookie.IsEssential = true;
            }); // Oturum i�lemleri servisi

            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Manager", "Admin", "SuperAdmin"));
                x.AddPolicy("UserPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Manager", "Admin", "SuperAdmin", "User", "Personel", "Guest"));
            });

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

            app.UseRouting();
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
