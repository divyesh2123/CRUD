using Microsoft.AspNetCore.Mvc;

namespace WebApplication8.Views
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
