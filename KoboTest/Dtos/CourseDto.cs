using KoboTest.Models;
using System.ComponentModel.DataAnnotations;

namespace KoboTest.Dtos
{
    public class CourseDto : BaseModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
    }

    public class AddCourseDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }
    }

    public class EditCourseDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
    }


}
