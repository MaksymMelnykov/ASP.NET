using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Lab7.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(FileModel file) 
        {
            if(ModelState.IsValid)
            {
                string fileContent = $"Name: {file.Name}\nSurname: {file.Surname}";

                byte[] buffer = Encoding.UTF8.GetBytes(fileContent);

                return File(buffer, "text/plain", $"{file.FileName}.txt");
            }
            return View(file);
        }
    }
}
