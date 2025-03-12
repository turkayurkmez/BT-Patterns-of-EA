using Microsoft.EntityFrameworkCore;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Infrastructure.Repositories
{
    public class CategoryRepository: BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        { }
    }
}
