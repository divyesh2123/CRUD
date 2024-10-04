using Microsoft.AspNetCore.Mvc;
using SessionExample.Models;

namespace SessionExample.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel loginViewModel)
        {
            if(loginViewModel.Email == "divyesh2198@gmail.com" && loginViewModel.Password == "Admin")
            {
                HttpContext.Session.SetString("Email", "divyesh2198@gmail.com");
                HttpContext.Session.SetInt32("UserId", 1);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
