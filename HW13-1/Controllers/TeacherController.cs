using HW13_1.Entities;
using HW13_1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HW13_1.Controllers;

public class TeacherController : Controller
{
    TeacherRipository teacherRipository=new TeacherRipository();
    public IActionResult Index()
    {
        return View(Database.OnlineTeacher);
    }

    [HttpPost]
    public IActionResult AddCourse(TrainingCourseDTO model)
    { 
        teacherRipository.AddTrainingCours(model);
        return RedirectToAction("GetTrainingCourse");
    }

    public IActionResult AddCourse()
    {
        return View();
    }

    public IActionResult GetTrainingCourse()
    {
        return View(teacherRipository.GetTrainingCourses());
    }

    public IActionResult AddGrade()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddGrade(GradeDTO gradeDTO)
    {
       // gradeDTO.CourseID = (int)TempData["CourseID"];
        teacherRipository.AddGrade(gradeDTO);
        return View();
    }

    public IActionResult GetStudentsOfCourse(int id)
    {
        //TempData["CourseID"] = id;
        return View(teacherRipository.GetStudents(id));
    }
}
