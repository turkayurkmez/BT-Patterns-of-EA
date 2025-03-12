using StockTracker.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Domain.Contracts
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
    }
}
