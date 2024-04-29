using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.Entities
{
    public class GameTests
    {
        [Theory()]
        [InlineData(10, 5, true)]
        [InlineData(5, 10, false)]
        public void Operator_GreaterThan_ShouldRerturnExpectedResult(decimal grade1, decimal grade2, bool expectedResult)
        {
            // Arrange
            var stu = new Game("Game 1 Id", "Game 1", "N64", grade1, 2000, "Game 1 Img");
            var game = new Game("Game 2 Id", "Game 2", "N64", grade2, 2000, "Game 2 Img");

            // Act
            var result = stu > game;

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory()]
        [InlineData(5, 10, true)]
        [InlineData(10, 5, false)]
        public void Operator_LesserThan_ShouldRerturnExpectedResult(decimal grade1, decimal grade2, bool expectedResult)
        {
            // Arrange
            var stu = new Game("Game 1 Id", "Game 1", "N64", grade1, 2000, "Game 1 Img");
            var game = new Game("Game 2 Id", "Game 2", "N64", grade2, 2000, "Game 2 Img");

            // Act
            var result = stu < game;

            // Assert
            result.Should().Be(expectedResult);
        }


        [Theory()]
        [InlineData(5, 5, true)]
        [InlineData(10, 5, false)]
        public void Operator_Equal_ShouldRerturnExpectedResult(decimal grade1, decimal grade2, bool expectedResult)
        {
            // Arrange
            var stu = new Game("Game 1 Id", "Game 1", "N64", grade1, 2000, "Game 1 Img");
            var game = new Game("Game 2 Id", "Game 2", "N64", grade2, 2000, "Game 2 Img");

            // Act
            var result = stu == game;

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory()]
        [InlineData(5, 10, true)]
        [InlineData(10, 10, false)]
        public void Operator_NotEqual_ShouldRerturnExpectedResult(decimal grade1, decimal grade2, bool expectedResult)
        {
            // Arrange
            var stu = new Game("Game 1 Id", "Game 1", "N64", grade1, 2000, "Game 1 Img");
            var game = new Game("Game 2 Id", "Game 2", "N64", grade2, 2000, "Game 2 Img");

            // Act
            var result = stu != game;

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
