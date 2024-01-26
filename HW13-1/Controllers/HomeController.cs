using HW13_1.Entities;
using HW13_1.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW13_1.Controllers;

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
        try
        {
            var loginUser = authentication.Login(model);
            if (loginUser.Role == Enum.RoleEnum.Student)
            {
                Database.OnlineStudent = (Student)loginUser;
                return RedirectToAction("Index", "Student");

            }
            else if (loginUser.Role == Enum.RoleEnum.Teacher)
            {
                Database.OnlineTeacher = (Teacher)loginUser;
                return RedirectToAction("Index", "Teacher");
            }
        }
        catch
        {
            ViewData["ShowAlert"] = "1";
            ViewData["AlertMessage"] = "Invalid username or password.";
        }
        return View("Login", model);

    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Index()
    {
        return View();
    }
}
