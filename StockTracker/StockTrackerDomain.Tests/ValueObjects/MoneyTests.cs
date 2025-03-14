using FluentAssertions;
using StockTracker.Domain.Exceptions;
using StockTracker.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackerDomain.Tests.ValueObjects
{
    public class MoneyTests
    {
        /*
         * Create_WithValidParameters_ShouldCreateMoney
         * Create_WithNegativeOrZeroAmount_ShouldThrowException
         * Create_WithNullOrEmptyCurrency_ShouldThrowException
         * Equality_WithSameValues_ShouldBeEqual
         * Equality_WithDifferentValues_ShouldNotBeEqual
         */

        [Fact]
        public void Create_WithValidParameters_ShouldCreateMoney()
        {
            //Arrange
            var amount = 100M;
            var currency = "TRY";
            //Act

            var money = new Money(amount,currency);
            //Assert
            money.Should().NotBeNull(); 
            money.Amount.Should().Be(amount);
            money.Currency.Should().Be(currency);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Create_WithNegativeOrZeroAmount_ShouldThrowException(decimal amount)
        {
            //Arrange
            var currency = "TRY";
            //Act
            Action action = () => new Money(amount, currency);
            //Assert
            action.Should().Throw<ArgumentException>().Where(e=>e.Message.Contains("küçük olamaz"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Create_WithNullOrEmptyCurrency_ShouldThrowException(string currency)
        {
            //Arrange
            var amount = 100M;
            //Act
            Action action = () => new Money(amount, currency);
            //Assert
            action.Should().Throw<ArgumentException>().Where(e => e.Message.Contains("boş olamaz"));
        }

        [Fact]
        public void Equality_WithSameValues_ShouldBeEqual()
        {
            //Arrange
            var amount = 100M;
            var currency = "TRY";
            var money1 = new Money(amount, currency);
            var money2 = new Money(amount, currency);
            //Act
            //Assert
            money1.Should().Be(money2);
        }

        [Fact]
        public void Equality_WithDifferentValues_ShouldNotBeEqual()
        {
            //Arrange
            var amount1 = 100M;
            var currency1 = "TRY";
            var amount2 = 200M;
            var currency2 = "USD";
            var money1 = new Money(amount1, currency1);
            var money2 = new Money(amount2, currency2);
            //Act
            //Assert
            money1.Should().NotBe(money2);
        }

    }
}
