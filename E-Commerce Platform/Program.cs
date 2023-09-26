using E_Commerce_Platform.DataBase;
using E_Commerce_Platform.Services.Abstracts;
using E_Commerce_Platform.Services.Concretes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews()
            .AddRazorRuntimeCompilation();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Services
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(o =>
            {
                o.Cookie.Name = "UserIdentity";
                o.LoginPath = "/user/login";
            });


            builder.Services
               .AddDbContext<ECommerceDBContext>(ob =>
               {
                   var connectionString = "Server=localhost;Port=5432;Database=ECommerceDataBase;User Id=postgres;Password=postgres;";
                  

                   ob.UseNpgsql(connectionString);
               })
               .AddScoped<IVerificationService, VerificationService>()
               .AddScoped<IUserService, UserService>() 
               .AddScoped<IEmailService, EmailService>()    
               .AddHttpContextAccessor()
               .AddHttpClient();








            var app = builder.Build();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            app.Run();
        }
    }
}