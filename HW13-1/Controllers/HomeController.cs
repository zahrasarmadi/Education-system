using HW13_1.Entities;
using HW13_1.Models;
using HW13_1.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW13_1.Controllers
{
    public class HomeController : Controller
    {
        Authentication authentication = new Authentication();

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterDTO model)
        {
            Person person = new Person()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Role = model.Role,
            };
            authentication.Register(person);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(LoginDTO model)
        {
            var loginUser = authentication.Login(model);
            if (loginUser.Role == Enum.RoleEnum.Student)
            { 
                return RedirectToAction("Index", "Student");
            }
            else if (loginUser.Role == Enum.RoleEnum.Teacher)
            {
                return RedirectToAction("Index", "Teacher");
            }
            return View(loginUser);
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}
