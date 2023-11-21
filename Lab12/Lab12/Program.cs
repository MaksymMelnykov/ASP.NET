using Lab12;
using Lab12.Models;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        IHost host = CreateHostBuilder(args).Build();

        using (ApplicationUserContext context = new ApplicationUserContext())
        {
            context.Users.AddRange(
                new User { Name = "Ivan", Surname = "Toney", Age = 28 },
                new User { Name = "Maksym", Surname = "Melnykov", Age = 19 },
                new User { Name = "Lionel", Surname = "Messi", Age = 35 }
            );

            context.SaveChanges();
            Console.WriteLine("Data added and saved");

            var users = context.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name} {user.Surname}, Age: {user.Age}");
            }
            Console.WriteLine();
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
