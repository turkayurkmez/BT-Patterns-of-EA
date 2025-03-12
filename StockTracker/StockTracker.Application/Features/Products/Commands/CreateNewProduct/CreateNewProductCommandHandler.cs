using Mapster;
using MediatR;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Contracts;

namespace StockTracker.Application.Features.Products.Commands.CreateNewProduct
{
    public class CreateNewProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateNewProductCommand, CreateNewProductCommandResponse>
    {
        public async Task<CreateNewProductCommandResponse> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
        {


            //pipeline behavior ile validation yapılacağı için bu kısım yorum satırına alındı.
            //CreateNewProductCommandValidator validations = new CreateNewProductCommandValidator();
            //var validationResult = await validations.ValidateAsync(request, cancellationToken);
            var product = request.Adapt<Product>();
            //Zaten BaseEntity'den gelen Id'yi Guid.NewGuid() ile set etmeye gerek yok.
            //product.Id = Guid.NewGuid();

            await unitOfWork.BeginTransactionAsync(cancellationToken);


            try
            {
                await repository.CreateAsync(product);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                await unitOfWork.CommitTransactionAsync(cancellationToken);

                return new CreateNewProductCommandResponse(product.Id);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw;
            }



        }
    }
}
