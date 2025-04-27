namespace JustCook.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-API-KEY", out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key is missing");
                return;
            }

            var AdminKey = _configuration["ApiKeys:AdminKey"];
            if (AdminKey != extractedApiKey)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Invalid API Key");
            }

            await _next(context);
        }
    }
}
