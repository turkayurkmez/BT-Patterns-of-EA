using MediatR;
using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Features.Products.Commands.CreateNewProduct
{
    public record CreateNewProductCommand(string Name, string SKU, string Description, Money Price, int StockQuantity, string? ImageUrl, int? CategoryId) : IRequest<CreateNewProductCommandResponse>;


    public record CreateNewProductCommandResponse(Guid LastProductId);

}
