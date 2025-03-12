using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockTracker.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x=>x.SKU).IsRequired().HasMaxLength(70);

            builder.Property(x => x.Description).HasMaxLength(500);

            builder.OwnsOne(p => p.Price, price => {
                price.Property(p => p.Amount).HasColumnName("Price").IsRequired();
                price.Property(p => p.Currency).HasColumnName("Currency").IsRequired().HasMaxLength(3);
            });

            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.StockQuantity).IsRequired();

            builder.HasOne(x => x.Category).WithMany()
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
