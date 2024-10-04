using Microsoft.AspNetCore.Mvc;
using SessionExample.Models;
using System.Diagnostics;

namespace SessionExample.Controllers
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

            string? UserName = HttpContext.Session.GetString("Email");
            int? UserId = HttpContext.Session.GetInt32("UserId");

            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.UserID = HttpContext.Session.GetInt32("UserId");
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