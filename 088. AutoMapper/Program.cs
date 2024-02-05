using _088._AutoMapper.Service;
using AutoMapper;
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
            builder.Services.AddAutoMapper(typeof(UserMappingProfile).Assembly);

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.MapControllers();


            app.MapControllerRoute(
                name: "default",
                pattern: "api/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
