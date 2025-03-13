using Eshop.EventBus;
using MassTransit;
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
    public class StockIncreaseEventHandler(ILogger<StockIncreaseEventHandler> logger, IPublishEndpoint publishEndpoint) : INotificationHandler<ProductStockIncreasedDomainEvent>
    {
        public async Task Handle(ProductStockIncreasedDomainEvent notification, CancellationToken cancellationToken)
        {
            
            logger.LogInformation($"{notification.ProductId} ürünün stoğu,  {notification.Quantity} adet arttırıldı");

            var stockIncreaseCommand = new ProductStockIncreasedCommand(notification.ProductId, notification.Quantity);
            var stockIncreaseEvent = new ProductStockIncreasedEvent(stockIncreaseCommand);
            await publishEndpoint.Publish(stockIncreaseEvent);
            //return Task.CompletedTask;
        }
    }
}
