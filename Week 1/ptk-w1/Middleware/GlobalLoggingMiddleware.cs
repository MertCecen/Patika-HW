using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ptk_w1.Middleware
{
    public class GlobalLoggingMiddleware
    {
        private readonly ILogger<GlobalLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public GlobalLoggingMiddleware(RequestDelegate next, ILogger<GlobalLoggingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log that an action is being executed
            _logger.LogInformation("An action is being executed.");

            // Call the next middleware in the pipeline
            await _next(context);

            // Log that the action has been executed
            _logger.LogInformation("Action executed.");
        }
    }
}
