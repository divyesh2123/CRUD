using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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


        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> IsEmailAvailable(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return Json("Please enter a valid email address.");
            }

            var emailAttribute = new EmailAddressAttribute();
            if (!emailAttribute.IsValid(email))
            {
                return Json("Please enter a valid email address.");
            }
            // Check if the email is already in use (case-insensitive)
            
            
            if (_userService.IsEmailAlreadyInUse(email))
            {
               
                return Json($"Email is already in use.");
            }
            // If the email is available
            return Json(true);

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
