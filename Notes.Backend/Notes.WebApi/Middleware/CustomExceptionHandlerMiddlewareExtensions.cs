using Microsoft.AspNetCore.Builder;

namespace Notes.WebApi.Middleware
{
    //Методы расширения для того, чтобы включать наш Middleware в конвейер
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}