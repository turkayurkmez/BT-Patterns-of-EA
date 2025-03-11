using StockTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Domain.Events
{
    public class ProductActivatedDomainEvent : DomainEvent
    {
        public Guid ProductId { get; private set; }
        public ProductActivatedDomainEvent(Guid productId)
        {
            ProductId = productId;
        }
    }
}
