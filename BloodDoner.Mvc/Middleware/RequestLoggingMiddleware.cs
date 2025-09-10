namespace BloodDoner.Mvc.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the incoming request
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
            // Call the next middleware in the pipeline
            await _next(context);
            // Log the outgoing response
            Console.WriteLine($"Response: {context.Response.StatusCode}");
        }
    }
}