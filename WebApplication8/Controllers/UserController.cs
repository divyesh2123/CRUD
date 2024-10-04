using Microsoft.AspNetCore.Mvc;
using WebApplication8.BussinessEntity;
using WebApplication8.BussinessService;
using WebApplication8.BussinessService.Concreate;

namespace WebApplication8.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditInfo(int id)
        {
            var p = _userService.GetUser(id);
            return View("Index",p);
        }

        [HttpPost]
        public IActionResult Index(UserViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }

            var d= _userService.AddUserInfo(user);
            TempData["message"] = "Data added...";
            return RedirectToAction("List");   

        }

        [HttpGet]
        public IActionResult List()
        {
            var data = _userService.GetUsers();
            return View(data);
        }

        [HttpGet]
        public IActionResult DeleteInfo(int id)
        {
            _userService.DeleteUser(id);
            TempData["message"] = "Data deleted...";
            return RedirectToAction("List");
        }

    }
}
