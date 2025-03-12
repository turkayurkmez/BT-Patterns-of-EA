using MediatR;
using Microsoft.EntityFrameworkCore;
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

