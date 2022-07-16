using KoboTest.Data;
using KoboTest.Interfaces;
using KoboTest.Models;
using Microsoft.EntityFrameworkCore;

namespace KoboTest.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> Get(int id);
    }
    public class StudentRepository :  Repository<Student>, IStudentRepository
    {
        public StudentRepository(KoboContext context) : base(context)
        {

        }
         
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await context.Students.Include(x => x.StudentCourses).ThenInclude(x => x.Course).Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Student> Get(int id)
        {
            return await context.Students.Include(x => x.StudentCourses).ThenInclude(x => x.Course).FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
        }
    }
}
