using StockTracker.Domain.Common;

namespace StockTracker.Domain.Events
{
    public class ProductDeactivatedDomainEvent : DomainEvent
    {
        public Guid ProductId { get; private set; }
        public ProductDeactivatedDomainEvent(Guid productId)
        {
            ProductId = productId;
        }
    }
}
