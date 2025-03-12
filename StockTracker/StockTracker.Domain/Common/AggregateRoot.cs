namespace StockTracker.Domain.Common
{
    public abstract class AggregateRoot<TId> : BaseEntity<TId>, IAggregateRoot where TId : struct, IEquatable<TId>
    {
        private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.AsReadOnly();

        public void ClearDomainEvents()
        {
            domainEvents.Clear();
        }

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }

    }
}
