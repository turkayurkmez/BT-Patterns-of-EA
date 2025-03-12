using Mapster;
using MediatR;
using StockTracker.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Features.Products.Queries.GetAllProducts
{
    internal class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, GetAllProductsQueryResponse>
    {
        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            return new GetAllProductsQueryResponse(products.Adapt<IEnumerable<ProductSummaryWithCategory>>());
        }
    }
}
