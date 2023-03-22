namespace Journey.Infrastructure
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
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
                Console.WriteLine($"Error: {ex.Message}");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("An error occurred while processing your request.");
            }
        }
    }

}
