using FluentAssertions;
using Moq;
using StockTracker.Application.Features.Products.Commands.CreateNewProduct;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Contracts;
using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.ApplicationTests.Features.Products.Commands.CreateNewProduct
{
    public class CreateNewProductCommandHandlerTests
    {
        private readonly Mock<IProductRepository> _productRepository;   
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly CreateNewProductCommandHandler _handler;

        public CreateNewProductCommandHandlerTests()
        {
            _productRepository = new Mock<IProductRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _handler = new CreateNewProductCommandHandler(_productRepository.Object, _unitOfWork.Object);
        }

        /*
         *  Handle_WithValidCommand_ShouldCreateProductAndReturnId
         */

        [Fact]
        public async Task Handle_WithValidCommand_ShouldCreateProductAndReturnId()
        {
            //Arrange
            var command = new CreateNewProductCommand(Name: "Test Product", SKU: "TP-001", Description: "Test Description", Price: new Money(100, "TRY"), StockQuantity: 10, ImageUrl: "https://test.com", CategoryId: 1);

            Product? capturedProduct = null;
            _productRepository.Setup(r=>r.CreateAsync(It.IsAny<Product>()))
                              .Callback<Product>(p => capturedProduct = p)
                              .Returns(Task.CompletedTask);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);



          
            //Assert
            result.Should().NotBeNull();
            result.LastProductId.Should().NotBe(Guid.Empty);

            _productRepository.Verify(r => r.CreateAsync(It.IsAny<Product>()), Times.Once);
            _unitOfWork.Verify(u => u.BeginTransactionAsync(CancellationToken.None), Times.Once);
            _unitOfWork.Verify(u => u.SaveChangesAsync(CancellationToken.None), Times.Once);
            _unitOfWork.Verify(u => u.CommitTransactionAsync(CancellationToken.None), Times.Once);

            capturedProduct.Should().NotBeNull();
            capturedProduct!.Name.Should().Be(command.Name);
            capturedProduct!.SKU.Should().Be(command.SKU);
            capturedProduct!.Description.Should().Be(command.Description);
            capturedProduct!.Price.Amount.Should().Be(command.Price.Amount);
            capturedProduct!.Price.Currency.Should().Be(command.Price.Currency);
            capturedProduct!.StockQuantity.Should().Be(command.StockQuantity);
            capturedProduct!.ImageUrl.Should().Be(command.ImageUrl);
            capturedProduct!.CategoryId.Should().Be(command.CategoryId);


        }

    }
}
