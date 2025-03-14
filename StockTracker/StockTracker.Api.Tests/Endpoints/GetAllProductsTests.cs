using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using StockTracker.Api.Tests.Infrastructure;
using StockTracker.Application.Features.Products.Queries.GetAllProducts;
using StockTracker.Application.Features.Products.Queries.GetProductsByCategory;
using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Api.Tests.Endpoints
{
    public class GetAllProductsTests : IClassFixture<StockTrackerApiTestsFixture>
    {
        private readonly StockTrackerApiTestsFixture _fixture;

        public GetAllProductsTests(StockTrackerApiTestsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnAllProducts()
        {
            //Arrange
            var productList = new List<ProductSummaryWithCategory>()
            {
                new ProductSummaryWithCategory
                (
                    Id: Guid.NewGuid(),
                    Name: "Product 1",
                    CategoryId : 1,
                    Price : new Money(100, "TRY"),
                    StockQuantity : 10
                ),
                new ProductSummaryWithCategory
                (
                    Id: Guid.NewGuid(),
                    Name: "Product 2",
                    CategoryId: 2,
                    Price : new Money(200, "TRY"),
                    StockQuantity : 20
                )
            };

            var queryResponse = new GetAllProductsQueryResponse(productList);

            _fixture.MediatorMock
                    .Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(queryResponse));

            //Act
            var response = await _fixture.Client.GetAsync("/products");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
           
            dynamic result = JsonConvert.DeserializeObject<dynamic>(responseContent);

            var test = result.products;

            //Assert:

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            //test.Should().NotBeNull();

            //test.Should().HaveCount(1);

            ////test.First().Id.Should().Be(productList.First().Id);
            //test.First().Name.Should().Be("Product X");
            //result.First().Price.Should().Be(new Money(200, "TRY"));
            //result.First().StockQuantity.Should().Be(200);
            ///result.First().CategoryID.Should().Should()

            //_fixture.MediatorMock.Verify(m => m.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()), Times.Once);










        }
    }
}
