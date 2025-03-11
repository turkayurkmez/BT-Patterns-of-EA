using Ardalis.GuardClauses;
using StockTracker.Domain.Common;
using StockTracker.Domain.Exceptions;
using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Domain.Aggregates
{
    public class Product : BaseEntity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }
        public string SKU { get; private set; }
        public string Description { get; private set; }
        public Money Price { get; private set; }
        public bool IsActive { get; private set; }
        public int StockQuantity { get; private set; }
        public string? ImageUrl { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        private Product()
        {
            // required by EF
        }

        public Product(string name, string sku, string description, Money price, bool isActive, int stockQuantity, string? imageUrl, int categoryId)
        {

            Guard.Against.NullOrEmpty(name, nameof(name), "Ürün adı boş olamaz");
            Guard.Against.NullOrEmpty(sku, nameof(sku), "Ürün sku boş olamaz");
            Guard.Against.NegativeOrZero(Price.Amount, nameof(Price), "Ürün fiyatı 0'dan küçük olamaz");


            Name = name;
            SKU = sku;
            Description = description;
            Price = price;
            IsActive = isActive;
            StockQuantity = stockQuantity;
            ImageUrl = imageUrl;
            CategoryId = categoryId;
        }

        public void UpdateProduct(string name, string sku, string description, Money price, string? imageUrl, int categoryId)
        {
            Guard.Against.NullOrEmpty(name, nameof(name), "Ürün adı boş olamaz");
            Guard.Against.NullOrEmpty(sku, nameof(sku), "Ürün sku boş olamaz");
            Guard.Against.NegativeOrZero(Price.Amount, nameof(Price), "Ürün fiyatı 0'dan küçük olamaz");

            Name = name;
            SKU = sku;
            Description = description;
            Price = price;
            CategoryId = categoryId;

            //IsActive = isActive;
            //StockQuantity = stockQuantity;

            //DİKKAT!
            //Bazı özelliklerin güncellenmesi için ekstra metotlar yazdık.

            ImageUrl = imageUrl;
        }

        public void IncreaseStock(int quantity)
        {
            Guard.Against.Negative(quantity, nameof(quantity), "Stok miktarı 0'dan küçük olamaz");
            StockQuantity += quantity;
        }

        public void DecreaseStock(int quantity)
        {
            
            Guard.Against.Negative(quantity, nameof(quantity),exceptionCreator: ()=>StockException.NegativeQuantity(Name,quantity));
            //if (quantity <= 0)
            //{
            //    throw StockException.NegativeQuantity(Name, quantity);
            //}

            if (StockQuantity < quantity)
            {
                throw StockException.InsuficcientStock(Name, quantity);
            }
            StockQuantity -= quantity;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;




    }
}
