using Lab10.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lab10.Controllers
{
    public class ConsultationController : Controller
    {
        public IActionResult Consultation()
        {
            return View();
        }

        [HttpPost]
        public string Consultation(Consultation model) 
        {
            if (ModelState.IsValid)
            {
                return $"Дані пройшли валідацію: {model.FullName} - {model.Email} - {model.ConsultationDate} - {model.SelectedProduct}";
            }
            return "Дані не пройшли валідацію";
        }
    }
}
