using Lab12.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab12.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationCompanyContext _context;

        public CompanyController(ApplicationCompanyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            _context.Companies.AddRange(
            new Company { CompanyName = "Apple", NumberOfEmployees = 164000, FoundationYear = 1976 },
            new Company { CompanyName = "Microsoft", NumberOfEmployees = 221000, FoundationYear = 1975 },
            new Company { CompanyName = "Google", NumberOfEmployees = 139995, FoundationYear = 1998 },
            new Company { CompanyName = "EA Sports", NumberOfEmployees = 98000, FoundationYear = 1991 },
            new Company { CompanyName = "Amazon", NumberOfEmployees = 1541000, FoundationYear = 1994 }
        );
            _context.SaveChanges();

            var companies = _context.Companies.ToList();
            return View(companies);
        }
    }
}
