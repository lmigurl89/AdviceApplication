namespace Advice.Data.Model
{
    public class Student : EntityBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int SchoolId { get; set; }
        public int CourseId { get; set; }

        public School? School { get; set; }
        public Course? Course { get; set; }

    }
}