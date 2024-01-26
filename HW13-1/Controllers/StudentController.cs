using HW13_1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HW13_1.Controllers;

public class StudentController : Controller
{
    StudentRepository studentRepository = new StudentRepository();
    TeacherRipository teacherRipository= new TeacherRipository();
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["userName"] = Database.OnlineStudent.FirstName;
        return View(Database.OnlineStudent);
    }

    public IActionResult AddCourse(int courseId)
    {
        studentRepository.AddCourse(courseId);
        return RedirectToAction("GetMyCourses");
    }
    public IActionResult GetCourses()
    {
        return View(teacherRipository.GetTrainingCourses());
    }
   public IActionResult GetMyCourses()
    {
        return View(studentRepository.GetCouse());
    }
    
    public IActionResult Exit()
    {
        Database.OnlineStudent = null;
        return RedirectToAction("Index", "Home");
    }
}
