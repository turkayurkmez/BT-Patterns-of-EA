using Ardalis.GuardClauses;

namespace StockTracker.Domain.ValueObjects
{
    public record Money
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; }
        public Money(decimal amount, string currency)
        {
            Guard.Against.NegativeOrZero(amount, nameof(amount), message: "Birim, 0'dan küçük olamaz");
            Guard.Against.NullOrEmpty(currency, nameof(currency), message: "Para birimi boş olamaz");
            //if (amount < 0)
            //{
            //    throw new ArgumentException("Birim, 0'dan küçük olamaz!");
            //}

            //if (string.IsNullOrWhiteSpace(currency))
            //{
            //    throw new ArgumentException("Para birimi boş olamaz!");
            //}



            Amount = amount;
            Currency = currency;
        }
    }
}
