using StockTracker.Domain.Common;

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
