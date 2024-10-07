using MarketMangement.MVC.Data;
using MarketMangement.Service.Implementations;
using MarketMangement.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarketMangement.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Database connection
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add Identity with roles and account confirmation requirement
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            // Dependency injection for PropertyService
            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddScoped<IDeviceCategoryService, DeviceCategoryService>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();


            // Add AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policyBuilder =>
                {
                    policyBuilder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                });
            });

            // Add Controllers with Views and Razor Pages
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Enable Developer Page Exception Filter for detailed error pages in development
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // Use HSTS in production
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Enable CORS
            app.UseCors("AllowAll");

            // Use authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Default route configuration
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
