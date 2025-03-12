using MediatR;
using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Features.Products.Queries.GetProductsByCategory
{
    public record GetProductsByCategoryQuery(int CategoryId) : IRequest<GetProductsByCategoryQueryResponse> ;

    public record ProductSummary(Guid Id, string Name, Money Price, int StockQuantity);

    public record GetProductsByCategoryQueryResponse(IEnumerable<ProductSummary> Products, int Count);



}
