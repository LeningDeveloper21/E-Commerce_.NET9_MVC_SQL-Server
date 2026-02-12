using Microsoft.EntityFrameworkCore;
using MyStore.Context;

namespace MyStore.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext _appDbContext) where TEntity : class
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _appDbContext.Set<TEntity>().ToListAsync();
        }
    }
}
