using System.Diagnostics;
using Annotations.Models;
using Microsoft.AspNetCore.Mvc;

namespace Annotations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: Employee Form
        public IActionResult Index()
        {
            return View();
        }

        // POST: Employee Form Submission
        [HttpPost]
        public IActionResult Index(Employee e)
        {
            if (ModelState.IsValid)
            {               
                ViewData["SuccessMessage"] = "The details are submitted successfully!";
                
                ModelState.Clear();

                return View();
            }
            return View(e);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
