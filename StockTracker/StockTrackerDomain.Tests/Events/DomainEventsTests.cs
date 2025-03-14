using FluentAssertions;
using StockTracker.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackerDomain.Tests.Events
{
    public class DomainEventsTests
    {
        /*
         * ProductStockIncreasedDomainEvent_ShouldSetProperties
         * ProductStockDecreasedDomainEvent_ShouldSetProperties
         * ProductActivatedDomainEvent_ShouldSetProperties
         * ProductDeactivatedDomainEvent_ShouldSetProperties
         */

        [Fact]
        public void ProductStockIncreasedDomainEvent_ShouldSetProperties()
        {
            //Arrange
            var productId = Guid.NewGuid();
            var quantity = 10;
            //Act
            var domainEvent = new ProductStockIncreasedDomainEvent(productId, quantity);
            //Assert
            domainEvent.ProductId.Should().Be(productId);
            domainEvent.Quantity.Should().Be(quantity);
        }

        [Fact]
        public void ProductStockDecreasedDomainEvent_ShouldSetProperties()
        {
            //Arrange
            var productId = Guid.NewGuid();
            var quantity = 10;
            //Act
            var domainEvent = new ProductStockDecreasedDomainEvent(productId, quantity);
            //Assert
            domainEvent.ProductId.Should().Be(productId);
            domainEvent.Quantity.Should().Be(quantity);
        }

        [Fact]
        public void ProductActivatedDomainEvent_ShouldSetProperties()
        {
            //Arrange
            var productId = Guid.NewGuid();
            //Act
            var domainEvent = new ProductActivatedDomainEvent(productId);
            //Assert
            domainEvent.ProductId.Should().Be(productId);
        }

        [Fact]
        public void ProductDeactivatedDomainEvent_ShouldSetProperties()
        {
            //Arrange
            var productId = Guid.NewGuid();
            //Act
            var domainEvent = new ProductDeactivatedDomainEvent(productId);
            //Assert
            domainEvent.ProductId.Should().Be(productId);
        }
    }
}
