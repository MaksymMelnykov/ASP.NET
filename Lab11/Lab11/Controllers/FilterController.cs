using Microsoft.AspNetCore.Mvc;
using Lab11.Filters;

namespace Lab11.Controllers
{
    [LogActionFilter]
    [UniqueUsersFilter]
    public class FilterController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello, world. This is the Index action method!!!");
        }

        public IActionResult About()
        {
            return Content("Hello, world. This is the About action method!!!");
        }
    }
}
