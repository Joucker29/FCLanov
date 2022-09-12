using fclanov.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace fclanov.Controllers
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



        public IActionResult mlpripravka()
        {
            return View();
        }

        public IActionResult stpripravka()
        {
            return View();
        }


        public IActionResult mlzaci()
        {
            return View();
        }


        public IActionResult stzaci()
        {
            return View();
        }

        public IActionResult mldorost()
        {
            return View();
        }


        public IActionResult amuzstvo()
        {
            return View();
        }



        public IActionResult hospoda()
        {
            return View();
        }








    }
}