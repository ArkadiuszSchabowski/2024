using _086.ThrowTraining.Exceptions;

namespace _086.ThrowTraining.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = 404; // Ustawienie odpowiedniego kodu statusu
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception)
            {
                // Obsługa innych wyjątków, jeśli to konieczne
                context.Response.StatusCode = 500; // Ustawienie odpowiedniego kodu statusu
                await context.Response.WriteAsync("Internal Server Error");
            }
        }
    }
}