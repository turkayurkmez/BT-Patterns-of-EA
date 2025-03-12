using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StockTracker.Domain.Contracts;
using StockTracker.Infrastructure.Data;
using StockTracker.Infrastructure.Repositories;
using StockTracker.Infrastructure.UnitOfWorks;

namespace StockTracker.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StockTrackerDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>(provider => new UnitOfWork(provider.GetRequiredService<StockTrackerDbContext>()));
            services.AddScoped<IProductRepository, ProductRepository>(provider => new ProductRepository(provider.GetRequiredService<StockTrackerDbContext>()));


            return services;
        }
    }
}
