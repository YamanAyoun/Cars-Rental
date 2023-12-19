using Cars_Rental.Data;
using Cars_Rental.Models;
using Cars_Rental.Models.Interface;
using Cars_Rental.Models.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Cars_Rental
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string Connection = builder.Configuration.GetConnectionString("DefaultConnection");


            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<CarRentDbContext>
               (option => option.UseSqlServer(Connection));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+";

            }).AddEntityFrameworkStores<CarRentDbContext>();

            builder.Services.AddTransient<IUserService, IdentityUserService>();

            builder.Services.AddTransient<ICompany, CompanyService>();
            builder.Services.AddTransient<ICar, CarService>();
            builder.Services.AddTransient<IEmployee, EmployeeService>();
            builder.Services.AddTransient<IBookingCar, BookingCarServices>();


            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
