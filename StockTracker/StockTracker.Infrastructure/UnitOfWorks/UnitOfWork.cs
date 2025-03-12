using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StockTracker.Domain.Contracts;

namespace StockTracker.Infrastructure.UnitOfWorks
{
    public class UnitOfWork(DbContext dbContext) :
        IUnitOfWork
    {
        private IDbContextTransaction _transaction;

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await dbContext.SaveChangesAsync(cancellationToken);
                await _transaction.CommitAsync(cancellationToken);
            }
            finally
            {

                await _transaction.DisposeAsync();
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _transaction.RollbackAsync(cancellationToken);
            }
            finally
            {

                await _transaction.DisposeAsync();
            }
        }



        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
