using MediatR;

namespace StockTracker.Domain.Common
{
    public abstract class DomainEvent : IDomainEvent, INotification
    {
        public Guid Id { get; protected set; }

        public DateTime OccurredOn { get; protected set; }

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }


}
