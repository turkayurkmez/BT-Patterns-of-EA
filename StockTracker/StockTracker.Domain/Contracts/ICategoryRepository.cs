using StockTracker.Domain.Aggregates;

namespace StockTracker.Domain.Contracts
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}
