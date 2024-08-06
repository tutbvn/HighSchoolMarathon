using HighSchoolMarathon.WebApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using HighSchoolMarathon.WebApp.Models;
using HighSchoolMarathon.DataAccess;
using HighSchoolMarathon.WebApp.Infrastructure;
using HighSchoolMarathon.DataAccess.Repositories;
using HighSchoolMarathon.WebApp.Controllers;

namespace HighSchoolMarathon.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //// Read and inject email configuration from appsettings.json
            var emailConfig = builder.Configuration
                    .GetSection("EmailSettings")
                    .Get<EmailSettings>() ?? new EmailSettings();
            builder.Services.AddSingleton(emailConfig);
            //builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("HighSchoolMarathonConnection") ?? throw new InvalidOperationException("Connection string 'HighSchoolMarathonConnection' not found.");
            builder.Services.AddDbContext<HighSchoolMarathonContext>(options =>
                options.UseSqlServer(connectionString));
            // builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<HighSchoolMarathonContext>().AddDefaultTokenProviders();
            builder.Services.AddControllersWithViews();

            //// Change service for Login
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "HighSchoolMarathon";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Account/Login";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            builder.Services.AddScoped<IEmailSender, EmailSender>();
            // Register the EventRepository
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<IRunnerRepository, RunnerRepository>();
            // Register NotificationController
            builder.Services.AddScoped<AutoAgentController>();

            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(MarathonProfile));
            // Add SignalR service
            builder.Services.AddSignalR();
            //builder.Services.AddSignalRCore();

            builder.Services.AddHostedService<AutoAgentService>();
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
           
            // Map the SignalR hub
            app.MapHub<MarathonEventHub>("/marathonEventHub");
            app.MapRazorPages();

            app.Run();
        }
    }
}
