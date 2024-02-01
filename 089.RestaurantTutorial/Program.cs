using _089.RestaurantTutorial.Entities;
using _089.RestaurantTutorial.Service;
using Microsoft.EntityFrameworkCore;

namespace _089.RestaurantTutorial
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();

            builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TutorialConnectionString")));

            builder.Services.AddScoped<SeederService>();
            builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetRequiredService<SeederService>();
                seeder.SeedRestaurantAndAdress();
                //seeder.AddDishesToWegetarianskaSwinka();
                seeder.DeleteWrongRecords();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
