using _089.RestaurantTutorial.Entities;
using _089.RestaurantTutorial.Middleware;
using _089.RestaurantTutorial.Service;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;

namespace _089.RestaurantTutorial
{
    public class Program
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TutorialConnectionString")));

            builder.Services.AddScoped<SeederService>();
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();
            builder.Services.AddAutoMapper(typeof(RestaurantMappingProfile).Assembly);
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Logging.AddNLog();

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Restaurant}/{action=Index}/{id?}");

            app.Run();
        }
    }
}