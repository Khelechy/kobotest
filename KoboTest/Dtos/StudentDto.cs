using KoboTest.Models;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }

    public class EditStudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class AddStudentCourseDto
    {
        [Required]
        public int? CourseId { get; set; }
    }

    public class RemoveStudentCourseDto
    {
        [Required]
        public int? CourseId { get; set; }
    }
}
