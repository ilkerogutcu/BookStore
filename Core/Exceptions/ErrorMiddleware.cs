using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.Exceptions
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
   
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }
   
        public async Task Invoke(HttpContext context)
        {
            string message = "";
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
   
            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";
                var response = new ExceptionResponse(message);
                var json = JsonConvert.SerializeObject(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
 
    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}