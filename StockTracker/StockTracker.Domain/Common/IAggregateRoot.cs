namespace StockTracker.Domain.Common
{
    public interface IAggregateRoot : IEntity
    {

        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
        void ClearDomainEvents();
    }
}
