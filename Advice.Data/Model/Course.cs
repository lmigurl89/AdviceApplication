namespace Advice.Data.Model
{
    public class Course : EntityBase 
    {
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }

        public Course()
        {
            Teachers = new();
            Students = new();
        }
    }
}