using Ardalis.GuardClauses;
using StockTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Domain.Aggregates
{
    public class Category :  BaseEntity<int>, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Category()
        {
            // required by EF
        }

        public Category(string name, string description)
        {
            Guard.Against.NullOrEmpty(name, nameof(name), "Kategori adı boş olamaz");
            Guard.Against.NullOrEmpty(description, nameof(description), "Kategori açıklaması boş olamaz");
            Name = name;
            Description = description;
        }

        public void UpdateCategory(string name, string description)
        {
            Guard.Against.NullOrEmpty(name, nameof(name), "Kategori adı boş olamaz");
            Guard.Against.NullOrEmpty(description, nameof(description), "Kategori açıklaması boş olamaz");
            Name = name;
            Description = description;
        }

        public void ClearDomainEvents()
        {
            throw new NotImplementedException();
        }
    }
}
