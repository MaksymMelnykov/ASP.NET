namespace Lab5
{
    public class CookieMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CookieMiddleware> _logger;

        public CookieMiddleware(RequestDelegate next, ILogger<CookieMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                if (context.Request.Path == "/")
                {
                    context.Response.ContentType = "text/html";

                    await context.Response.WriteAsync("<html><body>");
                    await context.Response.WriteAsync("<form method='post' action='/save-data'>");
                    await context.Response.WriteAsync("<label for='value'>Value:</label>");
                    await context.Response.WriteAsync("<input type='text' name='value' id='value'><br>");
                    await context.Response.WriteAsync("<label for='expirationDate'>Expiration Date:</label>");
                    await context.Response.WriteAsync("<input type='datetime-local' name='expirationDate' id='expirationDate'><br>");
                    await context.Response.WriteAsync("<input type='submit' value='Save Data'>");
                    await context.Response.WriteAsync("</form>");
                    await context.Response.WriteAsync("</body></html>");
                }
                else if (context.Request.Method == "POST" && context.Request.Path == "/save-data")
                {
                    var value = context.Request.Form["value"];
                    var expirationDateString = context.Request.Form["expirationDate"];

                    if (!string.IsNullOrEmpty(value) && DateTime.TryParse(expirationDateString, out DateTime expirationDate))
                    {
                        var cookieOptions = new CookieOptions
                        {
                            Expires = expirationDate,
                            HttpOnly = true
                        };
                        context.Response.Cookies.Append("CookieValue", value, cookieOptions);
                        context.Response.Cookies.Append("CookieExpirationDate", expirationDateString, cookieOptions);


                        await context.Response.WriteAsync("Data saved to cookie");
                    }
                    else
                    {
                        await context.Response.WriteAsync("Invalid data");
                    }
                }
                else if (context.Request.Path == "/check-cookie")
                {
                    var cookieValue = context.Request.Cookies["CookieValue"];
                    var cookieExpirationDate = context.Request.Cookies["CookieExpirationDate"];

                    if (!string.IsNullOrEmpty(cookieValue))
                    {
                        await context.Response.WriteAsync($"Cookie value: {cookieValue}");
                        await context.Response.WriteAsync($"    Cookie expiration date: {cookieExpirationDate}");
                    }
                    else
                    {
                        await context.Response.WriteAsync("Cookies doesn't exist");
                    }
                }

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
