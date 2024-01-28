using Microsoft.EntityFrameworkCore;
using WordMaster.Database;
using WordMaster.Services;

namespace WordMaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IWordService, WordService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<MyDbContext>(options => options.UseInMemoryDatabase("MyDb"));
            }
            else
            {
                builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WordMasterConnectionString")));
            }
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();

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
