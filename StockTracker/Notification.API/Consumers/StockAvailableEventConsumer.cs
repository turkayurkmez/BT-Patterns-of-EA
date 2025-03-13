using Eshop.EventBus;
using MassTransit;

namespace Notification.API.Consumers
{
    public class StockAvailableEventConsumer(ILogger<StockAvailableEventConsumer> logger) : IConsumer<StockAvailableEvent>
    {
        public Task Consume(ConsumeContext<StockAvailableEvent> context)
        {
            var command = context.Message.Command;
            logger.LogInformation($"Burası bildirim servisi. Stok mevcut. Sipariş No: {command.OrderId}, Müşteri No: {command.CustomerId}. Bildirim gönderildi");

            return Task.CompletedTask;
        }
    }

    public class StockNotAvailableEventConsumer(ILogger<StockNotAvailableEventConsumer> logger) : IConsumer<StockNotAvailableEvent>
    {
        public Task Consume(ConsumeContext<StockNotAvailableEvent> context)
        {
            var command = context.Message.Command;
            logger.LogInformation($"Burası bildirim servisi. Stok mevcut değil. Sipariş No: {command.OrderId}. Bildirim gönderildi");
            return Task.CompletedTask;
        }
    }

    public class ProductStockIncreasedEventConsumer(ILogger<ProductStockIncreasedEventConsumer> logger) : IConsumer<ProductStockIncreasedEvent>
    {
        public Task Consume(ConsumeContext<ProductStockIncreasedEvent> context)
        {
            var command = context.Message.Command;
            logger.LogInformation($"Burası bildirim servisi. Ürün stoğu arttırıldı. Ürün No: {command.ProductId}, Adet: {command.Quantity}. Bildirim gönderildi");
            return Task.CompletedTask;
        }
    }
}
