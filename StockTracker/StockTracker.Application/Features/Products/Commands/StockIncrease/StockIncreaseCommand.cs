using MediatR;

namespace StockTracker.Application.Features.Products.Commands.StockIncrease
{
    public record StockIncreaseCommand(Guid ProductId, int Quantity) : IRequest<StockIncreaseCommandResponse>;

    public record StockIncreaseCommandResponse(bool Success, string? Message);

}
