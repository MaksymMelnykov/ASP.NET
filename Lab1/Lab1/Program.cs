using System.Runtime.InteropServices;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<CompanyMiddleware>();

app.Run();

public class Company
{
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Address { get; set; }

    public Company(string name, string telephone, string address)
    {
        Name = name;
        Telephone = telephone;
        Address = address;
    }
}


public class CompanyMiddleware
{
    private readonly RequestDelegate _next;
    private Company _company;

    public CompanyMiddleware(RequestDelegate next)
    {
        _next = next;
        _company = new Company("My Company", "+380664065200", "Novobudivna street, 3");
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/company-info")
        {
            context.Response.ContentType = "text/plain; charset = utf - 8";
            await context.Response.WriteAsync($"Company Name: {_company.Name}\n");
            await context.Response.WriteAsync($"Telephone: {_company.Telephone}\n");
            await context.Response.WriteAsync($"Address: {_company.Address}\n");
        }
        else if(context.Request.Path == "/random-number")
        {
            int randomNumber = new Random().Next(0, 101);
            await context.Response.WriteAsync($"Random number between 0 and 100: {randomNumber}\n");      
        }
        else
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Page Not Found");
        }
    }
}