using System.Diagnostics;

namespace BookStore.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        readonly private RequestDelegate _next;
        readonly private ILogger<RequestLoggingMiddleware> _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopWatch = Stopwatch.StartNew();
            _logger.LogInformation("=> Request: {Method} {Path} {Query}", context.Request.Method, context.Request.Path, context.Request.Query);
            await _next(context);
            _logger.LogInformation("<= Response: {Method} {Path} responed {StatusCode} in {Time}", context.Request.Method, context.Request.Path, context.Response.StatusCode, stopWatch.ElapsedMilliseconds);

        }
    }
}
