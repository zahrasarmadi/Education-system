namespace HW13_1.Entities;
public class Student: Person
{
    public List<StudentCourse> Courses { get; set; } =new List<StudentCourse>();
}                    