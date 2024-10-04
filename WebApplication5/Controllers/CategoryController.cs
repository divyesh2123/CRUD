using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Display()
        {
            using Northwind3Context d = new();

            return View(d.Categories.ToList());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DeleteInfo(int id)
        {
            using Northwind3Context d = new();
            var record = d.Categories.SingleOrDefault(y => y.CategoryId == id);
            d.Categories.Remove(record);
            d.SaveChanges();    
            return RedirectToAction("Display");
        }

        public IActionResult EditInfo(int id)
        {
            using Northwind3Context d = new();
            var record = d.Categories.SingleOrDefault(y => y.CategoryId == id);
            return View("Index", record);
        }

        [HttpPost]
       public IActionResult Index(Category category)
        {
            using Northwind3Context d = new ();

            if(category.CategoryId == 0)
            {
                d.Categories.Add(category);

            }
            else
            {

                var recrod = d.Categories.SingleOrDefault(y => y.CategoryId == category.CategoryId);
                recrod.CategoryName = category.CategoryName;    
                recrod.Description = category.Description;  

            }
          
            d.SaveChanges();    
            return RedirectToAction("Display");
        }
    }
}
