using MediatR;
using StockTracker.Application.Features.Products.Queries.GetProductsByCategory;
using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery() : IRequest<GetAllProductsQueryResponse>;
    


    public record ProductSummaryWithCategory(Guid Id, string Name, Money Price, int StockQuantity, int? CategoryId);
    public record GetAllProductsQueryResponse(IEnumerable<ProductSummaryWithCategory> Products);
}
