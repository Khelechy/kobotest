using KoboTest.Data;
using KoboTest.Interfaces;
using KoboTest.Models;
using Microsoft.EntityFrameworkCore;

namespace KoboTest.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly KoboContext context;
        private DbSet<T> entities;
        public Repository(KoboContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll() => await entities.Where(x => x.IsDeleted == false).ToListAsync();

        public async Task<T> Get(int id) => await entities.FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);

        public async Task<T> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.Update(entity); 
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task SoftDelete(int id)
        {
            var entity = await entities.FirstOrDefaultAsync(s => s.Id == id);
            entity.IsDeleted = true;
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task HardDelete(int id)
        {
            var entity = await entities.FirstOrDefaultAsync(s => s.Id == id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
