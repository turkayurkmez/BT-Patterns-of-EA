using MediatR;
using StockTracker.Application.Features.Products.Queries.GetProductsByCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Features.Products.Queries.GetProduct
{
    public record GetProductByIdQuery(Guid Id) : IRequest<ProductSummary>;

}
