namespace Advice.Data.Model
{
    public class Teacher : EntityBase
    {
        public string Name { get; set; }
        public int SchoolId { get; set; }
        public int CourseId { get; set; }

        public School School { get; set; }
        public Course Course { get; set; }
    }
}