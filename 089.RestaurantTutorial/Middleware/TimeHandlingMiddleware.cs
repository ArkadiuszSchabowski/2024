
using System.Diagnostics;

namespace _089.RestaurantTutorial.Middleware
{
    public class TimeHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<TimeHandlingMiddleware> _logger;
        public Stopwatch _stopwatch;
        public TimeHandlingMiddleware(ILogger<TimeHandlingMiddleware> logger)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                _stopwatch.Start();
                await next.Invoke(context);
                _stopwatch.Stop();

                var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;


                if (elapsedMilliseconds > 1)
                {
                    var message = $"Time request {context.Request.Method} at {context.Request.Path} took {elapsedMilliseconds} ms";
                    _logger.LogInformation(message);
                }
            }
            catch (Exception)
            {

            }

        }
    }
}
