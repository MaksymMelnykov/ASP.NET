using Lab8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Product()
        {
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "iPhone 15 Pro Max", Price = 2187.89M, CreatedDate = DateTime.Now },
            new Product { Id = 2, Name = "Asus TUF Gaming F15", Price = 700M, CreatedDate = DateTime.Now },
            new Product { Id = 3, Name = "Samsung Galaxy Fold 5", Price = 2051.15M, CreatedDate = DateTime.Now },
            new Product { Id = 4, Name = "Телевізор \" Xiaomi Mi TV Q1 75\"", Price = 1367.43M, CreatedDate = DateTime.Now }
        };

            return View(products);
        }
    }
}
