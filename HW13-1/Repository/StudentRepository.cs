using HW13_1.Entities;

namespace HW13_1.Repository;

public class StudentRepository
{
    Serialization serializationST = new Serialization("student.json");
    Serialization serializationCS = new Serialization("trainingCourse.json");
    public void AddCourse(int courseId)
    {
        Database.students = serializationST.ReadFromFile<Student>();
        Database.trainingCourses = serializationCS.ReadFromFile<TrainingCourse>();
        var target = Database.trainingCourses.FirstOrDefault(c => c.Id == courseId);
        var targetStudent = Database.students.FirstOrDefault(s => s.Id == Database.OnlineStudent.Id);
        if (target.Students == null)
        {
            target.Students.Add(targetStudent);
        }
        else
        {
            target.Students.Add(Database.OnlineStudent);
        }
        var studentCourse = new StudentCourse()
        {
            trainingCourse = target
        };
        if (Database.OnlineStudent.Courses == null)
        {
            Database.OnlineStudent.Courses = new List<StudentCourse> { studentCourse };
        }
        else
        {
            Database.OnlineStudent.Courses.Add(studentCourse);
        }
        serializationCS.SaveToFileWhitWrite(Database.trainingCourses);
        serializationST.SaveToFileWhitWrite(Database.students);
    }
    public List<StudentCourse> GetCouse()
    {
        Database.students = serializationST.ReadFromFile<Student>();
        var studentCourse = Database.OnlineStudent.Courses;
        if(studentCourse==null)
        {
            return new List<StudentCourse>();
        }
        return studentCourse;
    }

}
