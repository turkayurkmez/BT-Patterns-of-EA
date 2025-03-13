namespace Eshop.EventBus
{
    public record IntegrationEvent
    {
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

    }
}
