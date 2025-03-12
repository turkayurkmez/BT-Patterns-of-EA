namespace StockTracker.Domain.Common
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        DateTime OccurredOn { get; }
    }

    public abstract class DomainEvent : IDomainEvent
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
