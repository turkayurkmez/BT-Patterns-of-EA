using FluentAssertions;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Events;
using StockTracker.Domain.Exceptions;
using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackerDomain.Tests.Aggregates
{


    public class ProductTests
    {
        private readonly Product _validProduct;
        public ProductTests()
        {
            _validProduct = new Product(
                name: "Test Product",
                sku: "TP-001",
                description: "Test Description", 
                price: new Money(100, "TRY"), 
                stockQuantity: 10, 
                imageUrl: "https://test.com", 
                categoryId: 1);


        }

        [Fact]
        public void CreateProduct_WithValidParameters_ShouldCreateProduct()
        {
            //Arrange

            //Act
           
            //Assert
            _validProduct.Name.Should().Be("Test Product");
            _validProduct.SKU.Should().Be("TP-001");
            _validProduct.Description.Should().Be("Test Description");
            _validProduct.Price.Amount.Should().Be(100);
            _validProduct.Price.Currency.Should().Be("TRY");
            _validProduct.StockQuantity.Should().Be(10);
            _validProduct.ImageUrl.Should().Be("https://test.com");
            _validProduct.CategoryId.Should().Be(1);
        }

        [Theory]
        [InlineData("", "TP-001", "Test Description")]
        [InlineData("Test Product", "", "Test Description")]
        public void CreateProduct_WithInvalidParameters_ShouldThrowException(string name, string sku, string description)
        {
            var price = new Money(100, "TRY");
            Action action = () => new Product(name, sku, description, price, 10, "https://test.com", 1);
            action.Should().Throw<ArgumentException>();
        }


        [Fact]
        public void IncreaseStock_WithValidQuantity_ShouldIncreaseStockAddDomainEvent()
        {
            //Arrange
            var initialStockQuantity = _validProduct.StockQuantity;
            var quantity = 5;


            //Act
            _validProduct.IncreaseStock(quantity);

            var totalAmount = initialStockQuantity + quantity;  
            //Assert
            _validProduct.StockQuantity.Should().Be(totalAmount);   

            _validProduct.DomainEvents.Should().HaveCount(1);
            _validProduct.DomainEvents.Should().ContainItemsAssignableTo<ProductStockIncreasedDomainEvent>();
            var @event = _validProduct.DomainEvents.OfType<ProductStockIncreasedDomainEvent>().First();
            @event.Should().NotBeNull();    
            @event!.ProductId.Should().Be(_validProduct.Id);
            @event.Quantity.Should().Be(quantity);




        }

        [Fact]
        public void IncreaseStock_WithNegativeQuantity_ShouldThrowException()
        {
            //Arrange
            var quantity = -5;
            //Act
            Action action = () => _validProduct.IncreaseStock(quantity);
            //Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void DecreaseStock_MoreThanAvailableStock_ShouldThrowException()
        {
            //Arrange
            var quantity = 15;
            //Act
            Action action = () => _validProduct.DecreaseStock(quantity);
            //Assert
            action.Should().Throw<StockException>();
        }

        [Fact]
        public void DecreaseStock_WithNegativeQuantity_ShouldThrowException()
        {
            //Arrange
            var quantity = -5;
            //Act
            Action action = () => _validProduct.DecreaseStock(quantity);
            //Assert
            action.Should().Throw<StockException>();
        }



    }
}
