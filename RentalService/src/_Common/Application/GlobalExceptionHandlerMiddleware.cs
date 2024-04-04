using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Common.Application
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware
        (
            RequestDelegate next
        )
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessException ex)
            {
                var json = new DefaultErrorResponse(
                    "A business exception occurred",
                    ex.Message);

                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(json));
            }
            catch (Exception ex)
            {
                var json = new DefaultErrorResponse(
                    "An unexpected error occurred. Please try again later.",
                    ex.Message);

                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(json));
            }
        }
    }
}
