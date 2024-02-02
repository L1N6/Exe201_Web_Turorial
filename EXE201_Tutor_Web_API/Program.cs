using EXE201_Tutor_Web_API.Base;
using Microsoft.Extensions.Configuration;

namespace EXE201_Tutor_Web_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<YourDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("YourConnectionString")));

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        }
    }
}