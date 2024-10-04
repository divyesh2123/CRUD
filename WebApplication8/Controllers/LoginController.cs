﻿using Microsoft.AspNetCore.Mvc;
using WebApplication8.BussinessEntity;
using WebApplication8.BussinessService;
using WebApplication8.BussinessService.Concreate;

namespace WebApplication8.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;
        public LoginController()
        {
            userService = new  UserService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel loginViewModel)
        {
            var d = userService.CheckLogin(loginViewModel.Name, loginViewModel.Password, out string message);
            
            if (d == false)
            {
                ViewBag.Message = message;
                return View(loginViewModel);

            }
            TempData["Message"] = message;
                
            return RedirectToAction("Index","User"); 
        }
    }
}
