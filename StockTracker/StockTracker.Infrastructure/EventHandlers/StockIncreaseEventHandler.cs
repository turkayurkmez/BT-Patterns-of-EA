using MediatR;
using Microsoft.Extensions.Logging;
using StockTracker.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Infrastructure.EventHandlers
{
    public class StockIncreaseEventHandler(ILogger<StockIncreaseEventHandler> logger) : INotificationHandler<ProductStockIncreasedDomainEvent>
    {
        public Task Handle(ProductStockIncreasedDomainEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation($"{notification.ProductId} ürünün stoğu,  {notification.Quantity} adet arttırıldı");
            return Task.CompletedTask;
        }
    }
}
