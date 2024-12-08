using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Landing.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplecationDbContext>(options =>
                options.UseSqlServer(connectionString));

            
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplecationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplecationDbContext>().AddDefaultUI().AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(30); // ??? ?????? ??????
                options.SlidingExpiration = true; // ????? ???????? ??? ?? ???????
                options.LoginPath = "/Account/Login"; // ???? ????? ??????
                options.LogoutPath = "/Account/Logout"; // ???? ????? ??????
            });


            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Register}/{id?}");

           


            app.MapRazorPages();

           


            app.Run();
        }
    }
}
