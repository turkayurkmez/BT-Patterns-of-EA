using MediatR;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Features.Products.Commands.CreateNewProduct
{
    public class CreateNewProductCommandHandler(IProductRepository repository) : IRequestHandler<CreateNewProductCommand, CreateNewProductCommandResponse>
    {
        public Task<CreateNewProductCommandResponse> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.SKU, request.Description, request.Price, request.StockQuantity, request.ImageUrl, request.CategoryId);


            repository.CreateAsync()
        }
    }
}
