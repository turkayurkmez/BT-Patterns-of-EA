using Eshop.EventBus;
using MassTransit;

namespace EShop.Services.Order.Consumers
{
    public class StockAvailableEventConsumer(ILogger<StockAvailableEventConsumer> logger) : IConsumer<StockAvailableEvent>
    {
        public Task Consume(ConsumeContext<StockAvailableEvent> context)
        {
            var command = context.Message.Command;
            logger.LogInformation($"Burası sipariş servisi. Stok mevcut. Sipariş No: {command.OrderId}, Müşteri No: {command.CustomerId}. Sipariş onaylandı");
            return Task.CompletedTask;
        }
    }

    public class StockNotAvailableEventConsumer(ILogger<StockNotAvailableEventConsumer> logger) : IConsumer<StockNotAvailableEvent>
    {
        public Task Consume(ConsumeContext<StockNotAvailableEvent> context)
        {
            var command = context.Message.Command;
            logger.LogInformation($"Burası sipariş servisi. Stok mevcut değil. Sipariş No: {command.OrderId}. Sipariş reddedildi");
            return Task.CompletedTask;
        }
    }
}
