using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Domain.Common
{
    public class AggregateRoot<TId> : BaseEntity<TId>, IAggregateRoot where TId: struct, IEquatable<TId>  
    {

    }
}
