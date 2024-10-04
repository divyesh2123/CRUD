using Microsoft.AspNetCore.Mvc;

namespace Myfirstapp.Controllers
{
    public class ProductController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult VieweProduct()
        {
            return View("../Home/index.cshtml");
        }
    }
}
