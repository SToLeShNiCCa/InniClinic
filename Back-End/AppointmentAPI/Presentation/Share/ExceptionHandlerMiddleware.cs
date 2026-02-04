using System.Net;
using System.Text.Json;

namespace Presentation.Share
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(ex, context);
            }
        }

        private async Task HandleException(Exception ex, HttpContext context)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var message = ex.Message;
            var stackTrace = ex.StackTrace;

            var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(exceptionResult);
        }
    }
}
