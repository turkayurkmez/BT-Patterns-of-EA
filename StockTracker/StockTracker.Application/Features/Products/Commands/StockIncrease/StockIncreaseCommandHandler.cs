using MediatR;
using StockTracker.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Features.Products.Commands.StockIncrease
{
    public class StockIncreaseCommandHandler(IProductRepository productRepository) : IRequestHandler<StockIncreaseCommand, StockIncreaseCommandResponse>
    {
        public async Task<StockIncreaseCommandResponse> Handle(StockIncreaseCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.ProductId);
            product.IncreaseStock(request.Quantity);
            await productRepository.UpdateAsync(product);

            return new StockIncreaseCommandResponse(true, "Stok başarıyla arttırıldı!");
        }

    }
}
