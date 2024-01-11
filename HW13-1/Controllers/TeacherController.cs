using Microsoft.AspNetCore.Mvc;

namespace HW13_1.Controllers;

public class TeacherController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
