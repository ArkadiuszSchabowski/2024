using _089.RestaurantTutorial.Entities;
using _089.RestaurantTutorial.Middleware;
using _089.RestaurantTutorial.Service;
using Microsoft.AspNetCore.Identity;
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
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IDishService, DishService>();
            builder.Services.AddAutoMapper(typeof(RestaurantMappingProfile).Assembly);
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<TimeHandlingMiddleware>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddSwaggerGen();
            builder.Logging.AddNLog();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var seederService = serviceProvider.GetRequiredService<SeederService>();
                seederService.SeedRoles();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMiddleware<TimeHandlingMiddleware>();

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant Api"));
            app.UseAuthorization();

            app.MapControllers();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Restaurant}/{action=Index}/{id?}");

            app.Run();
        }
    }
}