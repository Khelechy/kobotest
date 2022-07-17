using KoboTest.Data;
using KoboTest.Interfaces;
using KoboTest.Models;
using Microsoft.EntityFrameworkCore;

namespace KoboTest.Repositories
{

    public interface IStudentCourseRepository : IRepository<StudentCourse>
    {
        Task<IEnumerable<StudentCourse>> GetStudentCourses(int id);
        Task<StudentCourse> GetStudentByCourseId(int studentId, int id);
    }
    public class StudentCourseRepository : Repository<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(KoboContext context) : base(context)
        {

        }

        public async Task<StudentCourse> GetStudentByCourseId(int studentId, int id)
        {
            return await context.StudentCourses.FirstOrDefaultAsync(x => x.StudentId == studentId && x.CourseId == id);
        }

        public async Task<IEnumerable<StudentCourse>> GetStudentCourses(int id)
        {
            return await context.StudentCourses.Where(x => x.StudentId == id).ToListAsync();
        }
    }
}
