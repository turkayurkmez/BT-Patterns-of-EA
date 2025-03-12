namespace StockTracker.Domain.Common
{
    public interface IEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
