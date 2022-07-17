using KoboTest.Models;

namespace KoboTest.Dtos
{
    public class StudentDto : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
    }

    public class AddStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class EditStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class AddStudentCourseDto
    {
        public int CourseId { get; set; }
    }

    public class RemoveStudentCourseDto
    {
        public int CourseId { get; set; }
    }
}
