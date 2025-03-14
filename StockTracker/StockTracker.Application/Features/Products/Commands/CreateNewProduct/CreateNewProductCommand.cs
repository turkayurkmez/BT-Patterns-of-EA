using MediatR;
using StockTracker.Domain.ValueObjects;

namespace StockTracker.Application.Features.Products.Commands.CreateNewProduct
{
    public record CreateNewProductCommand(string Name, string SKU, string Description, Money Price, int StockQuantity, string? ImageUrl, int? CategoryId) : IRequest<CreateNewProductCommandResponse>
    {
        public string Currency { get; set; }
    }

    public record CreateNewProductCommandResponse(Guid LastProductId);

}
