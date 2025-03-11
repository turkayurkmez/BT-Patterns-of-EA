using StockTracker.Domain.Common;

namespace StockTracker.Domain.Events
{
    public class ProductStockIncreasedDomainEvent : DomainEvent
    {
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public ProductStockIncreasedDomainEvent(Guid productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
