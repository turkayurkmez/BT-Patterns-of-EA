using Mapster;
using MediatR;
using StockTracker.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Features.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductsByCategoryQuery, GetProductsByCategoryQueryResponse>
    {
        public async Task<GetProductsByCategoryQueryResponse> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetProductsByCategoryAsync(request.CategoryId);
            var summaryResponse = products.Adapt<IEnumerable<ProductSummary>>();
            return new GetProductsByCategoryQueryResponse(summaryResponse, summaryResponse.Count());
            //var response = new GetProductsByCategoryQueryResponse(products,);

        }
    }
}
