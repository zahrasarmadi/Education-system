using HW13_1.Entities;
using HW13_1.Models;
using HW13_1.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW13_1.Controllers
{
    public class HomeController : Controller
    {
        Authentication authentication=new Authentication();
       
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO model)
        {
            authentication.Register((Person)model);
            return RedirectToAction("Login");
        }

        [HttpPost]
         public IActionResult Login(string email,string password)
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
