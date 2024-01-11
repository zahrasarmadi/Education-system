namespace HW13_1.Entities;
public class TrainingCourse
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public int Capacity { get; set; }
    public Course Course { get; set; }
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; set; } 
}