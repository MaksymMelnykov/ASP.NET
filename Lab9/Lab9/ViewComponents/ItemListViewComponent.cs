using Microsoft.AspNetCore.Mvc;
using Lab9.Models;

namespace Lab9.ViewComponents
{
    public class ItemListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Item> items)
        {
            return View(items);
        }
    }
}
