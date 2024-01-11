using Microsoft.AspNetCore.Mvc;

namespace HW13_1.Controllers;

public class StudentController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
