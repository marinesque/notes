using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Notes.Application.Common.Exceptions;
using FluentValidation;

namespace Notes.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        //Конструктор принимает параметр RequestDelegate next, который вызывает следующий делегат запросов в конвейере
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next) =>
            _next = next;

        //Метод будет перехватывать делегат next и обрабатывать исключения 
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
                throw;
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //Если ошибка валидации, возвращаем bad request, а в результат записываем ошибки валидации
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException: 
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                //Отлавливаем наше кастомное исключение NotFound
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { errpr = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}