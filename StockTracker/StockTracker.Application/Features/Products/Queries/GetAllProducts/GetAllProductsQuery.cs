using MediatR;
using StockTracker.Domain.ValueObjects;

namespace StockTracker.Application.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery() : IRequest<GetAllProductsQueryResponse>;



    public record ProductSummaryWithCategory(Guid Id, string Name, Money Price, int StockQuantity, int? CategoryId);
    public record GetAllProductsQueryResponse(IEnumerable<ProductSummaryWithCategory> Products);
}
