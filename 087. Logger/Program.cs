namespace _087._Logger
{
    public class Program
    {
        private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            _logger.Info("App started!");
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
