using FluentAssertions;
using Moq;
using StockTracker.Application.Features.Products.Queries.GetAllProducts;
using StockTracker.Domain.Aggregates;
using StockTracker.Domain.Contracts;
using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.ApplicationTests.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandlerTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly GetAllProductsQueryHandler _handler;
        private readonly List<Product> _testProducts;

        public GetAllProductsQueryHandlerTests() {
            _mockProductRepository = new Mock<IProductRepository>();
            _handler = new GetAllProductsQueryHandler(_mockProductRepository.Object);
            _testProducts = new List<Product>
            {
                new Product("Test Product 1", "TP-001", "Test Description 1", new Money(100, "TRY"), 10, "https://test.com", 1),
                new Product("Test Product 2", "TP-002", "Test Description 2", new Money(200, "TRY"), 20, "https://test.com", 2),
                new Product("Test Product 3", "TP-003", "Test Description 3", new Money(300, "TRY"), 30, "https://test.com", 3)
            };

            for (int i = 0; i < _testProducts.Count; i++)
            {
                var propertyInfo = typeof(Product).GetProperty("Id");
                propertyInfo.SetValue(_testProducts[i], Guid.NewGuid());
            }
        }

        [Fact]
        public async Task Handle_GetAllProductsShouldReturnAllProducts() 
        { 
            var query = new GetAllProductsQuery();
            _mockProductRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(_testProducts);

            //act:
            var result = await _handler.Handle(query, CancellationToken.None);

            //assert:
            result.Should().NotBeNull();
            result.Products.Should().NotBeNull();
            result.Products.Should().HaveCount(_testProducts.Count);

            foreach (var expected in _testProducts) { 
                result.Products.Should().Contain(p=> p.Id == expected.Id 
                                                  && p.Name == expected.Name
                                                  && p.Price == expected.Price
                                                  && p.StockQuantity == expected.StockQuantity
                                                  && p.CategoryId == expected.CategoryId);
            }

            _mockProductRepository.Verify(r => r.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_GetAllProductsShouldReturnEmptyListWhenNoProductsExist()
        {
            var query = new GetAllProductsQuery();
            _mockProductRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Product>());
            //act:
            var result = await _handler.Handle(query, CancellationToken.None);
            //assert:
            result.Should().NotBeNull();
            result.Products.Should().NotBeNull();
            result.Products.Should().BeEmpty();
            _mockProductRepository.Verify(r => r.GetAllAsync(), Times.Once);
        }

    }
}
