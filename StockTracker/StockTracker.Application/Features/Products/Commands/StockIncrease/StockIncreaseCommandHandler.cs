using MediatR;
using StockTracker.Domain.Contracts;

namespace StockTracker.Application.Features.Products.Commands.StockIncrease
{
    public class StockIncreaseCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<StockIncreaseCommand, StockIncreaseCommandResponse>
    {
        public async Task<StockIncreaseCommandResponse> Handle(StockIncreaseCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.ProductId);
            product.IncreaseStock(request.Quantity);


            await unitOfWork.BeginTransactionAsync();
            try
            {
                await productRepository.UpdateAsync(product);
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitTransactionAsync();
                return new StockIncreaseCommandResponse(true, "Stok başarıyla arttırıldı!");
            }
            catch (Exception)
            {

                await unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw;
            }





        }

    }
}
