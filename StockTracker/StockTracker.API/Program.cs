using Eshop.EventBus;
using MassTransit;

using MediatR;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using StockTracker.API.Consumers;
using StockTracker.Application.Extensions;
using StockTracker.Application.Features.Products.Commands.CreateNewProduct;
using StockTracker.Application.Features.Products.Commands.StockIncrease;
using StockTracker.Application.Features.Products.Queries.GetAllProducts;
using StockTracker.Application.Features.Products.Queries.GetProduct;
using StockTracker.Infrastructure.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructureServices(connectionString!);

builder.Services.AddMassTransit(regConfig =>
{
    regConfig.AddConsumer<OrderCreatedEventConsumer>(cc =>
    {
        cc.UseMessageRetry(retry =>
        {
            retry.Intervals(TimeSpan.FromSeconds(5),
                            TimeSpan.FromSeconds(10), 
                            TimeSpan.FromSeconds(20));

            //retry.Exponential(5, TimeSpan.FromSeconds(5),TimeSpan.FromMinutes(1), TimeSpan.FromSeconds(1));
            retry.Handle<TimeoutException>();


        });

        //1 dakika içinde 10 tane hata olursa, bu hatalar 10 aktif istek içindeyse o zaman işlemi durdur

        cc.UseCircuitBreaker(cb =>
        {
            cb.TrackingPeriod = TimeSpan.FromMinutes(1); //1 dakika içinde
            cb.TripThreshold = 10; //10 hata olursa
            cb.ActiveThreshold = 10; //10 aktif istek içinde
            cb.ResetInterval = TimeSpan.FromMinutes(5); //devre kesici, 5 dakika sonra resetlenir
        });

    });
    regConfig.UsingRabbitMq((context, config) => {

        config.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        config.ConfigureEndpoints(context);
        //fan out: bir mesajı alan tüm consumerlara gönderir
        config.Publish<StockAvailableEvent>(x=>x.ExchangeType = ExchangeType.Fanout);
        config.Publish<StockNotAvailableEvent>(x => x.ExchangeType = ExchangeType.Fanout);


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

app.MapGet("/products", async (IMediator mediator) =>
{
    var query = new GetAllProductsQuery();
    var result = await mediator.Send(query);
    return Results.Ok(result);

});

app.MapGet("/products/{id}", async (IMediator mediator, string id) =>
{
    var query = new GetProductByIdQuery(Guid.Parse(id));
    var result = await mediator.Send(query);

    if (result == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(result);
});

app.MapPost("/products", async (IMediator mediator, CreateNewProductCommand command) =>
{
    var result = await mediator.Send(command);
    return Results.Created($"/products/{result.LastProductId.ToString()}", result);
});

app.MapPut("/products/{id}", async (IMediator mediator, string id, StockIncreaseCommand command) =>
{  


    var result = await mediator.Send(command);
    return Results.Ok(result);
});




app.Run();

