using HW13_1.Entities;

namespace HW13_1.Repository;

public class StudentRepository
{
    Serialization serializationST = new Serialization("student.json");
   // Serialization serializationCS = new Serialization("trainingCourse.json");
    public void AddCourse(int courseId)
    {
      
        Database.students = serializationST.ReadFromFile<Student>();
        var target = Database.trainingCourses.FirstOrDefault(c => c.Id == courseId);
        var targetStudent = Database.students.FirstOrDefault(s => s.Id == Database.OnlineStudent.Id);
  
            var studentCourse = new StudentCourse()
            {
                trainingCourse = target
            };
            if (targetStudent.Courses == null)
            {
                targetStudent.Courses = new List<StudentCourse> { studentCourse };
            }
            else
            {
                targetStudent.Courses.Add(studentCourse);
            }
            serializationST.SaveToFileWhitWrite(Database.students);

    }
    public List<StudentCourse> GetCouse()
    {
        Database.students = serializationST.ReadFromFile<Student>();
        var studentCourse = Database.students.FirstOrDefault(s => s.Id == Database.OnlineStudent.Id).Courses;
        if (studentCourse == null)
        {
            return new List<StudentCourse>();
        }
        return studentCourse;
    }

    public string GetNameBy(int id)
    {
        var students = serializationST.ReadFromFile<Student>();
        var studentName = students.FirstOrDefault(x => x.Id == id).FirstName;
        return studentName;
    }
}