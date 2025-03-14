using Mapster;
using MediatR;
using StockTracker.Domain.Contracts;

namespace StockTracker.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, GetAllProductsQueryResponse>
    {
        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            return new GetAllProductsQueryResponse(products.Adapt<IEnumerable<ProductSummaryWithCategory>>());
        }
    }
}
