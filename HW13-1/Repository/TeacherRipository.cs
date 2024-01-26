using HW13_1.Entities;

namespace HW13_1.Repository;

public class TeacherRipository
{
    Serialization serializationCS = new Serialization("trainingCourse.json");
     Serialization serializationTR = new Serialization("teacher.json");
    Serialization serializationST = new Serialization("student.json");
    public void AddTrainingCours(TrainingCourseDTO trainingCourse)
    {
        Database.trainingCourses= serializationCS.ReadFromFile<TrainingCourse>();
        var newest = new TrainingCourse()
        {
            Capacity = trainingCourse.Capacity,
            StartTime = trainingCourse.StartTime,
            Name = trainingCourse.Name,
            Teacher = Database.OnlineTeacher,
        };
        Database.trainingCourses.Add(newest);
        serializationCS.SaveToFileWhitWrite(Database.trainingCourses);
    }
     
    public void AddGrade(GradeDTO gradeDTO)
    {
        Database.students = serializationST.ReadFromFile<Student>();
        Database.students
            .FirstOrDefault(s => s.Id == gradeDTO.StudentId).Courses
            .FirstOrDefault(c => c.trainingCourse.Id == gradeDTO.CourseId).Grade = gradeDTO.Grade;
        serializationST.SaveToFileWhitWrite(Database.students);

    }

    public List<Student> GetStudents(int courseId)
    {
        Database.students = serializationST.ReadFromFile<Student>();

        var target = Database.students.Where(s => s.Courses.Any(c => c.trainingCourse.Id == courseId)).ToList();

        if (target == null)
        {
            return new List<Student>();
        }
        return target;
    }
    
    public List<TrainingCourse> GetTrainingCourses()
    {
        Database.trainingCourses = serializationCS.ReadFromFile<TrainingCourse>();
        return Database.trainingCourses;
    }
}
