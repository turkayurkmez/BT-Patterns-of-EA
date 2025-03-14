using FizzBuzz.Game;
using FluentAssertions;

namespace FizzBuzz.Tests
{
    public class GameTest
    {
        //[Fact]
        //public void IsExists()
        //{
        //    var gameBoard = new FizzBuzz.Game.GameBoard();
        //    string word = gameBoard.GetWord(1);

        //}

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(7)]
        public void When_send_a_number_should_return_a_word(int number)
        {
            //3A Pattern (AAA Pattern)
            //Arrange
            var gameBoard = new GameBoard();
            //Act:
            string word = gameBoard.GetWord(number);
            //Assert:
            //Assert.Equal("2", word);

            word.Should().Be(number.ToString());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        public void When_send_a_number_divisible_by_3_should_return_Fizz(int number)
        {
            //Arrange
            var gameBoard = new GameBoard();
            //Act:
            string word = gameBoard.GetWord(number);
            //Assert:
            word.Should().Be("Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        public void When_send_a_number_divisible_by_5_should_return_Buzz(int number)
        {
            //Arrange
            var gameBoard = new GameBoard();
            //Act:
            string word = gameBoard.GetWord(number);
            //Assert:
            word.Should().Be("Buzz");
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        public void When_send_a_number_divisible_by_3_and_5_should_return_FizzBuzz(int number)
        {
            //Arrange
            var gameBoard = new GameBoard();
            //Act:
            string word = gameBoard.GetWord(number);
            //Assert:
            word.Should().Be("FizzBuzz");
        }
    }
}