using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.Entities
{
    public class MatchTests
    {
        [Fact]        
        public void Contructor_DiffGrades_ShouldPlaceWinnerWithTheGreaterGrade()
        {
            // Arrange
            var gameA = new Game("Game a Id", "Game a", "N64", 10, 2000, "Game a Img");
            var gameB = new Game("Game b Id", "Game b", "N64", 5, 2000, "Game b Img");

            // Act
            var stu = new Match(gameA, gameB);

            // Assert
            stu.Winner.Should().Be(gameA);
            stu.Loser.Should().Be(gameB);
        }

        [Fact]
        public void Contructor_SameGrades_ShouldPlaceWinnerWithGreaterYear()
        {
            // Arrange
            var gameA = new Game("Game a Id", "Game a", "N64", 10, 2001, "Game a Img");
            var gameB = new Game("Game b Id", "Game b", "N64", 10, 2000, "Game b Img");

            // Act
            var stu = new Match(gameA, gameB);

            // Assert
            stu.Winner.Should().Be(gameA);
            stu.Loser.Should().Be(gameB);
        }

        [Fact]
        public void Contructor_SameGrades_ShouldPlaceWinnerWithAlphabeticalOrder()
        {
            // Arrange
            var gameA = new Game("Game a Id", "Game a", "N64", 10, 2000, "Game a Img");
            var gameB = new Game("Game b Id", "Game b", "N64", 10, 2000, "Game b Img");

            // Act
            var stu = new Match(gameA, gameB);

            // Assert
            stu.Winner.Should().Be(gameA);
            stu.Loser.Should().Be(gameB);
        }
    }
}
