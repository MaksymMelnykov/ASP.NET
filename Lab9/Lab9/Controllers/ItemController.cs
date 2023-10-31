using Lab9.Models;
using Microsoft.AspNetCore.Mvc;


namespace Lab9.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            var items = new List<Item>
            {
                new Item { Id = 1, Name = "iPhone 15 Pro Max", Price = 2187.89M },
                new Item { Id = 2, Name = "Asus TUF Gaming F15", Price = 700M },
                new Item { Id = 3, Name = "Samsung Galaxy Fold 5", Price = 2051.15M },
                new Item { Id = 4, Name = "Телевізор \" Xiaomi Mi TV Q1 75\"", Price = 1367.43M }
            };

            return View(items);
        }
    }
}