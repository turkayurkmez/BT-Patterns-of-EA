using Mapster;
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
        public async Task<CreateNewProductCommandResponse> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
        {


            //pipeline behavior ile validation yapılacağı için bu kısım yorum satırına alındı.
            //CreateNewProductCommandValidator validations = new CreateNewProductCommandValidator();
            //var validationResult = await validations.ValidateAsync(request, cancellationToken);
            var product = request.Adapt<Product>();
            //Zaten BaseEntity'den gelen Id'yi Guid.NewGuid() ile set etmeye gerek yok.
            //product.Id = Guid.NewGuid();
           

            await repository.CreateAsync(product);

            return new CreateNewProductCommandResponse(product.Id);



        }
    }
}
