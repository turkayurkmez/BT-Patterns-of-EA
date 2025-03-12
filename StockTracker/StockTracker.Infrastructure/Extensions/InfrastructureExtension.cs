using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockTracker.Application.Features.Products.Queries.GetAllProducts;
using StockTracker.Domain.Contracts;
using StockTracker.Infrastructure.Data;
using StockTracker.Infrastructure.EventHandlers;
using StockTracker.Infrastructure.Repositories;
using StockTracker.Infrastructure.UnitOfWorks;
using System.Reflection;

namespace StockTracker.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StockTrackerDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>(provider => new UnitOfWork(provider.GetRequiredService<StockTrackerDbContext>()));
            services.AddScoped<IProductRepository, ProductRepository>(provider => new ProductRepository(provider.GetRequiredService<StockTrackerDbContext>()));

            services.AddMediatR(cfg =>
            {

                cfg.RegisterServicesFromAssemblyContaining<GetAllProductsQuery>();
                cfg.RegisterServicesFromAssemblyContaining<StockIncreaseEventHandler>();


            });
            return services;
        }
    }
}
