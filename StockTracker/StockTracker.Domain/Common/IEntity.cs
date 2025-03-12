using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Domain.Common
{
    public interface IEntity
    {
         DateTime CreatedAt { get; set; }
         DateTime? UpdatedAt { get; set; }
    }
}
