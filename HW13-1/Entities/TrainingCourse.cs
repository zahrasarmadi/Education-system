using HW13_1.Repository;

namespace HW13_1.Entities;
public class TrainingCourse
{
    public int Id { get; set; } = Database.TrainingCourseCounter++;
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public Teacher Teacher { get; set; }
    public int Capacity { get; set; }
    public List<Student> Students { get; set; }
}