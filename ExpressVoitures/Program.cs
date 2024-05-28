using ExpressVoitures.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using ExpressVoitures.Models.Repositories;
using ExpressVoitures.Models.Services;
using Microsoft.AspNetCore.Mvc.Razor;

namespace ExpressVoitures
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews()
               .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
               .AddDataAnnotationsLocalization();

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("fr-FR"),
                };

                options.DefaultRequestCulture = new RequestCulture("fr-FR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<IModeleRepository, ModeleRepository>();
            builder.Services.AddScoped<IFinitionRepository, FinitionRepository>();
            builder.Services.AddScoped<IYearRepository, YearRepository>();
            builder.Services.AddScoped<ICarsService, CarsService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            // Generate password hash for admin
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                var password = "Admin@123456";
                var adminUser = new IdentityUser { UserName = "admin@example.com", Email = "admin@example.com" };
                var passwordHash = userManager.PasswordHasher.HashPassword(adminUser, password);

                Console.WriteLine($"Password hash: {passwordHash}");

                // Initialize roles and admin user
                var services = scope.ServiceProvider;
                await SeedData.Initialize(services);
            }

            // Use localization
            app.UseRequestLocalization();

            app.Run();
        }
    }
}
