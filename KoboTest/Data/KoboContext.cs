using KoboTest.Models;
using Microsoft.EntityFrameworkCore;

namespace KoboTest.Data
{
    public class KoboContext : DbContext
    {
        public KoboContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
