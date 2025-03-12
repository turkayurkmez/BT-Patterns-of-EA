using Microsoft.EntityFrameworkCore;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Contracts;

namespace StockTracker.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await _dbSet.Where(p => p.Name.Contains(name)).ToListAsync();

        }
    }
}
