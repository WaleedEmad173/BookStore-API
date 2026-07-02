using BookStore.Application.Exceptions;
using System.Net;

namespace BookStore.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _Logger;
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _Logger = logger;
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

                var (statuscode, message) = ex switch
                {
                    NotFoundException => (HttpStatusCode.NotFound, ex.Message),
                    BadRequestException => (HttpStatusCode.BadRequest, ex.Message),
                    DuplicateException => (HttpStatusCode.Conflict, ex.Message),
                    _ => (HttpStatusCode.InternalServerError, "An unexpected error occurred!")
                };
                if (statuscode == HttpStatusCode.InternalServerError)
                    _Logger.LogError(ex, $"An unexpected error occurred: {ex.Message}");
                else
                    _Logger.LogWarning("A handled error occurred: {Type} - {Message}", ex.GetType().Name, ex.Message);


                context.Response.StatusCode = (int)statuscode;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    status = (int)statuscode,
                    message = message
                });

            }
        }
    }
}
