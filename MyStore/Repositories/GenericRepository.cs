using Microsoft.EntityFrameworkCore;
using MyStore.Context;
using System.Linq.Expressions;

namespace MyStore.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext _appDbContext) where TEntity : class
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _appDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>[] includes)
        {

            IQueryable<TEntity> query = _appDbContext.Set<TEntity>();

            foreach (var include in includes) query = query.Include(include);


            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _appDbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _appDbContext.Set<TEntity>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _appDbContext.Set<TEntity>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
