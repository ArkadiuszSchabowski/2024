
using api.Exceptions;

namespace api.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
            await next.Invoke(context);
            }
            catch(ConflictException e)
            {
                context.Response.StatusCode = 409;
                await context.Response.WriteAsync(e.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Blad serwera");
            }
        }
    }
}
