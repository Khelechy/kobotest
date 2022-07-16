namespace KoboTest.Models
{
    public class Student : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
