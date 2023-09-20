using Microsoft.AspNetCore.Hosting;

namespace Lab3
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Task1
            services.AddTransient<CalcService>();
            
            //Task2
            services.AddTransient<TimeOfDayService>();
            
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
