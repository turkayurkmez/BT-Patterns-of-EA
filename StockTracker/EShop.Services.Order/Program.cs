using Eshop.EventBus;
using EShop.Services.Order.Consumers;
using MassTransit;
namespace EShop.Services.Order
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMassTransit(regConfig =>
            {
                regConfig.AddConsumer<StockAvailableEventConsumer>();
                regConfig.AddConsumer<StockNotAvailableEventConsumer>();
                regConfig.UsingRabbitMq((context, config) => {

                    config.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    config.ConfigureEndpoints(context);

                    config.ReceiveEndpoint("stock-available-event", e =>
                    {
                        e.ConfigureConsumer<StockAvailableEventConsumer>(context);
                    });

                    config.ReceiveEndpoint("stock-not-available-event", e =>
                    {
                        e.ConfigureConsumer<StockNotAvailableEventConsumer>(context);
                    });

                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

          

            app.MapPost("/orderCreate",(IPublishEndpoint publishEndpoint, OrderCreateRequest request) =>
            {
                var orderItems = request.OrderItems.Select(x => new OrderItem(x.ProductId, x.Quantity, x.Price));
                var orderId = new Random().Next(1000, 10000);
                var command = new OrderCreatedCommand(orderId, request.CustomerId, request.CreditCardInfo,orderItems);

                var @event = new OrderCreatedEvent(command);

                //yeni sipariş oluşturulduğunda, sipariş mikroservisi olay yayınlar.

                publishEndpoint.Publish(@event);

                return Results.Created($"/orderCreate/{orderId}", orderId);
            });

            app.Run();


        }


    }

    public record OrderCreateRequest(string CustomerId, string CreditCardInfo, IEnumerable<OrderItem> OrderItems);
    public record OrderItemInRequest(int ProductId, int Quantity, decimal Price);
}
