using StockTracker.Domain.Common;

namespace StockTracker.Domain.Contracts
{
    public interface IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
                                              where TId : struct, IEquatable<TId>

    {

        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();



    }
}
