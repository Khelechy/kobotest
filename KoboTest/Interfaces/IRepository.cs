using KoboTest.Models;

namespace KoboTest.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
    }
}
