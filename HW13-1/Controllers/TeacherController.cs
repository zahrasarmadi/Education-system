using HW13_1.Entities;
using HW13_1.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace HW13_1.Controllers;

public class TeacherController : Controller
{
    TeacherRipository teacherRipository = new TeacherRipository();
    StudentRepository studentRepository = new StudentRepository();
    public IActionResult Index()
    {
        ViewData["userName"] = Database.OnlineTeacher.FirstName;
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

    public IActionResult AddGrade(int id, int courseId,string studentName)
    {
        var gradeDTO = new GradeDTO()
        {
            StudentId = id,
            StudentName = studentName,
            CourseId = courseId
        };
        ViewData["StudentName"]=gradeDTO.StudentName;
        ViewData["CourseId"]=gradeDTO.CourseId;
        ViewData["StudentId"] = gradeDTO.StudentId;
        return View();
    }

    [HttpPost]
    public IActionResult AddGrade(GradeDTO gradeDTO)
    {
        teacherRipository.AddGrade(gradeDTO);

        return RedirectToAction("GetTrainingCourse");
    }

    public IActionResult GetStudentsCourse(int id)
    {
        var result = teacherRipository.GetStudents(id);
        ViewData["CourseId"] = id;
        ViewBag.CourseId = id;
        return View(result);
    }

    public IActionResult Exit()
    {
        Database.OnlineTeacher = null;
        return RedirectToAction("Index", "Home");
    }
}
