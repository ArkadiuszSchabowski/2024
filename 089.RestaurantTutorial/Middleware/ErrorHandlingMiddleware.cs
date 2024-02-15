using _089.RestaurantTutorial.Exceptions;
using System.Text.Json;

namespace _089.RestaurantTutorial.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, "NotFoundException caught: {0}", e.Message);
                HandleException(context, e, 404, "Nie znaleziono restauracji o podanym Id!");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception caught: {0}", e.Message);
                HandleException(context, e, 500, "Something went wrong!");
            }
        }

        private void HandleException(HttpContext context, Exception exception, int statusCode, string message)
        {
            _logger.LogError(exception, exception.Message);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            context.Response.WriteAsync(JsonSerializer.Serialize(new { error = message }));

            _logger.LogDebug("Exception handled successfully."); // Dodaj to
        }
    }
}