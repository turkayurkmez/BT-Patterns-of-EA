using Mapster;
using MediatR;
using StockTracker.Application.Features.Products.Queries.GetProductsByCategory;
using StockTracker.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Features.Products.Queries.GetProduct
{
    public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, ProductSummary>
    {
        public async Task<ProductSummary> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetByIdAsync(request.Id);
            return product.Adapt<ProductSummary>();
        }
    }
}
