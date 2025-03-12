using MediatR;
using Microsoft.EntityFrameworkCore;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Infrastructure.Data
{
    public class StockTrackerDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        private readonly IMediator _mediator;

        public StockTrackerDbContext(DbContextOptions<StockTrackerDbContext> options, IMediator mediator):base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StockTrackerDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            //bu fonksiyonda, db işlemi tamamlandıktan sonra; olaylar fırlatılmalı....

            //1. olay bulunan dbSet'leri bul:
            var domainEntities = ChangeTracker.Entries<IAggregateRoot>()
                                              .Where(x => x.Entity.DomainEvents != null 
                                                       && x.Entity.DomainEvents.Any()
                                               );


            //2. olayları topla
            var domainEvents = domainEntities.SelectMany(x => x.Entity.DomainEvents)
                                             .ToList();



            domainEntities.ToList()
                         .ForEach(entity => entity.Entity.ClearDomainEvents());
            //3. olayları fırlat:
            foreach (var @event in domainEvents)
            {
                await _mediator.Publish(@event);
            }

            //4. olayları temizle:

           





            foreach (var item in ChangeTracker.Entries<IEntity>())
            {
                switch (item.State)
                {                  
                    case EntityState.Modified:
                        item.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedAt = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
