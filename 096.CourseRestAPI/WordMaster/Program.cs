using Microsoft.EntityFrameworkCore;
using WordMaster.Database;
using WordMaster.Services;
using WordMaster.Middleware;

namespace WordMaster
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IWordService, WordService>();
            builder.Services.AddScoped<ErrorHandlingMiddleware>();

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<MyDbContext>(options => options.UseInMemoryDatabase("MemoryDatabase"));
            }
            else
            {
                builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WordMasterConnectionString")));
            }

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

        }
    }
}
