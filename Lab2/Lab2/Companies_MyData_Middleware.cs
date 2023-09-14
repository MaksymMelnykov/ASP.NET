using Microsoft.Extensions.Options;
using System.Globalization;

namespace Lab2
{
    public class Companies_MyData_Middleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public Companies_MyData_Middleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //----------------------Task1----------------------
            if (context.Request.Path == "/")
            {
                var microsoftEmployees = _configuration.GetValue<int>("microsoftEmployees");
                var appleEmployees = _configuration.GetValue<int>("appleEmployees");
                var googleEmployees = _configuration.GetValue<int>("googleEmployees");

                var totalEmployees = microsoftEmployees + appleEmployees + googleEmployees;

                var companyName = "Unknown";

                if (microsoftEmployees > appleEmployees && microsoftEmployees > googleEmployees)
                {
                    companyName = "Microsoft";
                }
                else if (appleEmployees > microsoftEmployees && appleEmployees > googleEmployees)
                {
                    companyName = "Apple";
                }
                else
                {
                    companyName = "Google";
                }

                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Company with the most employees: {companyName}<br/>");
                await context.Response.WriteAsync($"Total employees in all companies: {totalEmployees}\n");
            }
            //----------------------Task2----------------------
            else if ( context.Request.Path == "/myData")
            {
                var name = _configuration.GetValue<string>("Name");
                var age = _configuration.GetValue<int>("Age");
                var city = _configuration.GetValue<string>("City");
                var university = _configuration.GetValue<string>("University");

                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Name: {name}<br/>");
                await context.Response.WriteAsync($"Age: {age}<br/>");
                await context.Response.WriteAsync($"City: {city}<br/>");
                await context.Response.WriteAsync($"University: {university}<br/>");
            }
        }
    }
}
