using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Store.Sokhna.BLL;
using Store.Sokhna.BLL.Interfaces;
using Store.Sokhna.BLL.Repositories;
using Store.Sokhna.DAL.Data.Contexts;
using Store.Sokhna.DAL.Models;
using Store.Sokhna.PL.HelperClasses;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Store.Sokhna.PL
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("Connection1")); });
            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/LogIn";
            });
			builder.Services.AddScoped<IUnitofWork, UnitOfWork>();
			builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
			var app = builder.Build();


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
