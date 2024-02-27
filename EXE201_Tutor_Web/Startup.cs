using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using EXE201_Tutor_Web_API.Services.MailService;
using EXE201_Tutor_Web.Models;
using EXE201_Tutor_Web.Service.VnPayService;

namespace EXE201_Tutor_Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure session
            services.AddSession();
            services.AddHttpClient();
            // Configure authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                });
            services.AddSession();
            // Configure authorization
            services.AddAuthorization();
            services.AddTransient<ISendMailService, SendMailService>();
            var mailsettings = Configuration.GetSection("MailSettings");
            services.Configure<MailSetting>(mailsettings);
            services.AddHttpClient();
            // Configure MVC
            services.AddControllersWithViews();

            //// Configure Entity Framework Core
            var connectionString = Configuration.GetConnectionString("MyCnn");
            services.AddDbContext<EXE_DataBaseContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            // 
            services.AddScoped<VnPayService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
