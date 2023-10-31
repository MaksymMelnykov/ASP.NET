using Microsoft.AspNetCore.Mvc;

namespace Lab9.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
