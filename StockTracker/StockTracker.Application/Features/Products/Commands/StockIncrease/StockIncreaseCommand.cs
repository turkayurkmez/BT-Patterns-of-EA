using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Features.Products.Commands.StockIncrease
{
    public record StockIncreaseCommand(Guid ProductId, int Quantity) : IRequest<StockIncreaseCommandResponse>;

    public record StockIncreaseCommandResponse(bool Success, string? Message);

}
