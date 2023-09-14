using Microsoft.Extensions.Configuration;

namespace Lab2
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("microsoft.json")
                .AddJsonFile("myData.json")
                .AddXmlFile("apple.xml")
                .AddIniFile("google.ini")
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<Companies_MyData_Middleware>();
        }
    }
}
