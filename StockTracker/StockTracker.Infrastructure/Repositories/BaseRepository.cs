using Microsoft.EntityFrameworkCore;
using StockTracker.Domain.Common;
using StockTracker.Domain.Contracts;

namespace StockTracker.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity, TId> : IRepository<TEntity, TId>
                                                        where TEntity : BaseEntity<TId>
                                                        where TId : struct, IEquatable<TId>


    {


        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TId id)
        {
            return await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException($"{id} Id'li entity bulunamadı");
        }

        public Task UpdateAsync(TEntity entity)
        {
            //_dbSet.Update(entity);
            //alternatif olarak:
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;


        }
    }
}
