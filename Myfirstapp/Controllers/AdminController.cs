using Microsoft.AspNetCore.Mvc;

namespace Myfirstapp.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
