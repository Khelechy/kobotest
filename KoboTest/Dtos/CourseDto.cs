using KoboTest.Models;

namespace KoboTest.Dtos
{
    public class CourseDto : BaseModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
    }

    public class AddCourseDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
    }

    public class EditCourseDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
    }


}
