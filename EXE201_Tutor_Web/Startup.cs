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
using EXE201_Tutor_Web.Entities;
using Microsoft.AspNetCore.Authentication.Google;

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
            services.AddSession();
            // Configure authorization
            services.AddAuthentication(option =>
            {
                option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(GoogleDefaults.AuthenticationScheme, option =>
            {
                option.ClientId = Configuration.GetSection("GoogleKeys:ClientId").Value;
                option.ClientSecret = Configuration.GetSection("GoogleKeys:ClientSecret").Value;

            });
            services.AddAuthorization();

            // Configure Mail
            services.AddTransient<ISendMailService, SendMailService>();
            var mailsettings = Configuration.GetSection("MailSettings");
            services.Configure<MailSetting>(mailsettings);

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
