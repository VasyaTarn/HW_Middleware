using HW_Middleware.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW_Middleware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string[] logs;
            if(System.IO.File.Exists("logs.txt"))
            {
                logs = System.IO.File.ReadAllLines("logs.txt");
            }
            else
            {
                logs = new string[0]; 
            }

            return View(logs); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
