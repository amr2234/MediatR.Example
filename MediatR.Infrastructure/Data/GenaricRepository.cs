

using MediatR.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;


namespace MediatR.Infrastructure.Data
{
    public class GenaricRepository<T> : IGenericRepository<T> where T : class
    {
        protected DBContext_App _context;
        protected DbSet<T> dbSet;
        public GenaricRepository(DBContext_App context)
        {
            _context = context;

            dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {

            return await dbSet.FindAsync(id);

        }

        public virtual async Task<bool> Add(T entity)
        {

            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {

            var entity = await dbSet.FindAsync(id);

            dbSet.Remove(entity);
            return true;


        }

        public virtual async Task<bool> Update(T entity)
        {
            dbSet.Update(entity);
            return true;
        }
    }
}
