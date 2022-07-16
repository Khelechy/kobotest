namespace KoboTest.Models
{
    public class StudentCourse : BaseModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
