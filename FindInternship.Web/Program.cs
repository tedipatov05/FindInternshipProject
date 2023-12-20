using CloudinaryDotNet;
using FindInternship.Common;
using FindInternship.Core.Hubs;
using FindInternship.Data;
using FindInternship.Data.Models;
using FindInternship.Web.Extensions;
using FindInternship.Web.Hubs;
using FindInternship.Web.Middlewares;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindInternship.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("FindInternshipDbContextConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<FindInternshipDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.ConfigureServices();

            var emailConfig = builder.Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfig>();

            builder.Services.AddSingleton(emailConfig);

            ConfigureCloudinaryService(builder.Services, builder.Configuration);

            builder.Services.AddDefaultIdentity<User>(options =>
            {

                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<FindInternshipDbContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";


            });

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            builder.Services
                .AddControllersWithViews(options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                });

            builder.Services.AddResponseCaching();

            builder.Services.AddSignalR();

            var app = builder.Build();

            app.MapHub<RequestHub>("/requestHub");
            app.MapHub<MeetingHub>("/meetingHub");

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

            app.UseCors();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<OnlineUserMiddleware>();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });

           

            app.MapRazorPages();

            app.Run();
        }

        private static void ConfigureCloudinaryService(IServiceCollection services, IConfiguration configuration)
        {

            var cloudName = configuration.GetValue<string>("AccountSettings:CloudName");
            var apiKey = configuration.GetValue<string>("AccountSettings:ApiKey");
            var apiSecret = configuration.GetValue<string>("AccountSettings:ApiSecret");

            if (new[] { cloudName, apiKey, apiSecret }.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("Please specify your Cloudinary account Information");
            }

            services.AddSingleton(new Cloudinary(new Account(cloudName, apiKey, apiSecret)));
        }
    }
}