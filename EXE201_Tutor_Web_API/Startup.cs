using EXE201_Tutor_Web_API.Base;
using EXE201_Tutor_Web_API.Database;
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
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



