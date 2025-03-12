using StockTracker.Domain.Aggregates;

namespace StockTracker.Domain.Contracts
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> SearchByNameAsync(string name);

    }
}
