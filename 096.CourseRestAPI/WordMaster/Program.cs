using Microsoft.EntityFrameworkCore;
using WordMaster.Database;
using WordMaster.Services;
using NLog;
using NLog.Web;

namespace WordMaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //logger
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("Init Main");
            //end logger

            try
            {

                var builder = WebApplication.CreateBuilder(args);

                builder.Services.AddControllersWithViews();

                if (builder.Environment.IsDevelopment())
                {
                    builder.Services.AddDbContext<MyDbContext>(options => options.UseInMemoryDatabase("MemoryDatabase"));
                }
                else
                {
                    builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WordMasterConnectionString")));
                }
                //logger

                builder.Logging.ClearProviders();
                builder.Host.UseNLog();

                //end logger

                builder.Services.AddScoped<IWordService, WordService>();

                var app = builder.Build();

                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
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
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }
}
