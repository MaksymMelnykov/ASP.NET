namespace Lab5
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<CookieMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
