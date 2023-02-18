using Microsoft.AspNetCore.Mvc;
using MMSApp.Models;
using System.Diagnostics;
using MMSModel.DTO; 
using MMSModel.Entity;

namespace MMSApp.Controllers
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
            PSPDto dt1 = new PSPDto();
            Psp p1 = new();
            List<Psp> lst = new();


            dt1 = p1;

            p1 = dt1;
            return View();
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