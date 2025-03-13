using Eshop.EventBus;
using MassTransit;

namespace StockTracker.API.Consumers
{
    public class OrderCreatedEventConsumer(ILogger<OrderCreatedEventConsumer> logger) : IConsumer<OrderCreatedEvent>
    {
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var command = context.Message.Command;
            logger.LogInformation($"Burası stok servisi. Sipariş oluşturuldu. Sipariş No: {command.OrderId}, Müşteri No: {command.CustomerId}");

            bool isStockAvailable = checkStock(command.OrderItems);

            if (isStockAvailable)
            {
                var stockAvailableCommand = new StockAvailabeCommand(command.OrderId, command.CustomerId, command.CreditCardInfo, command.OrderItems.Sum(x => x.Quantity * x.Price));
                var stockAvailableEvent = new StockAvailableEvent(stockAvailableCommand);
                await context.Publish(stockAvailableEvent);
            }
            else
            {
                var stockNotAvailableCommand = new StockNotAvailableCommand(command.OrderId);
                var stockNotAvailableEvent = new StockNotAvailableEvent(stockNotAvailableCommand);
                await context.Publish(stockNotAvailableEvent);
            }

            await Task.CompletedTask;


        }

        private bool checkStock(IEnumerable<OrderItem> orderItems)
        {
            return new Random().Next(0, 10) > 5;
        }
    }
}
