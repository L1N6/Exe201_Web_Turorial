    using EXE201_Tutor_Web_API.Base;
using EXE201_Tutor_Web_API.Base.Repository;
using EXE201_Tutor_Web_API.Base.Service;
using EXE201_Tutor_Web_API.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EXE201_Tutor_Web_API
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
            
            var connectionString = Configuration.GetConnectionString("MyCnn");
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddDbContext<Exe201_Tutor_Context>(options =>
            options.UseSqlServer(connectionString));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped(typeof(IBaseService<,,>), typeof(BaseService<,,>));

            //Confige Google Service
            services.AddAuthentication(options =>
            {
                //Accuracy Cookie 
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            }).AddCookie().AddGoogle(googleOptions =>
            {
                //Accuracy Google
                googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



