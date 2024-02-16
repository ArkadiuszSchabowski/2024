using _086.ThrowTraining.Middleware;
using _086.ThrowTraining.Service;

namespace _086.ThrowTraining
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddScoped<IAnimalService, AnimalService>();
            builder.Services.AddScoped<ErrorHandlingMiddleware>();

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
