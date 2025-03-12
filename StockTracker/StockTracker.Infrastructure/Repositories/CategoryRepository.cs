using Microsoft.EntityFrameworkCore;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Contracts;

namespace StockTracker.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        { }
    }
}
