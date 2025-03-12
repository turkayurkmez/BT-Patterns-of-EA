using StockTracker.Domain.Common;

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
