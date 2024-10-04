using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            Northwind3Context context = new Northwind3Context();    

            var products = context.Categories.ToList();    
            return View(products);
        }
    }
}
