using Lab6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class PizzaOrderController : Controller
    {
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(User user)
        {
            if (user.Age > 16)
            {
                return RedirectToAction("SelectQuantity");
            }
            return View("InvalidRegistration", user);
        }

        [HttpGet]
        public IActionResult SelectQuantity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PizzaOrder(int quantity)
        {
            var products = new List<Product>();
            for (int i = 0; i < quantity; i++)
            {
                products.Add(new Product());
            }
            return View(products);
        }

        [HttpPost]
        public IActionResult PizzaOrderResult(List<Product> products)
        {
            return View(products);
        }
    }
}
