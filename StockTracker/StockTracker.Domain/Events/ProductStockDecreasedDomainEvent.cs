using StockTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Domain.Events
{
    public class ProductStockDecreasedDomainEvent : DomainEvent
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public ProductStockDecreasedDomainEvent(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

    }
}
