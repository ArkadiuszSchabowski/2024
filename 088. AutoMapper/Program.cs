using _088._AutoMapper.Service;
using AutoMapper.Database;
using Microsoft.EntityFrameworkCore;

namespace _088._AutoMapper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<MyDbContext>(d => d.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnectionString")));
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseRouting();

            app.Run();
        }
    }
}
