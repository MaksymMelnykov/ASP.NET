namespace Lab5
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception: {ex.Message}");
                using (var writer = new StreamWriter("error_log.txt", append: true))
                {
                    await writer.WriteLineAsync($"[{DateTime.UtcNow}] Exception: {ex.Message}");
                    await writer.WriteLineAsync(new string('-', 100));
                }
            }
        }
    }
}
