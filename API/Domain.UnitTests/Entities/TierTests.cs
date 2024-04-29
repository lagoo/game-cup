using Domain.Entities;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
namespace Domain.UnitTests.Entities
{
    public class TierTests
    {
        [Fact]
        public void Contructor_OneMatch_ShouldMarkAsFinalAndNameBeFinal()
        {
            // Arrange
            var gameA = new Game("Game a Id", "Game a", "N64", 10, 2000, "Game a Img");
            var gameB = new Game("Game b Id", "Game b", "N64", 5, 2001, "Game b Img");
            var matchA = new Match(gameA, gameB);
            var matchList = new List<Match>() { matchA };

            // Act
            var stu = new Tier(matchList, 1);

            // Assert
            stu.IsFinal.Should().BeTrue();
            stu.Name.Should().Be("Final");
        }

        [Fact]
        public void Contructor_TwoMatch_ShouldNotMarkAsFinalAndNameBeSemiFinal()
        {
            // Arrange
            var gameA = new Game("Game a Id", "Game a", "N64", 10, 2000, "Game a Img");
            var gameB = new Game("Game b Id", "Game b", "N64", 5, 2001, "Game b Img");
            var gameC = new Game("Game c Id", "Game c", "N64", 1, 2002, "Game c Img");
            var matchA = new Match(gameA, gameB);
            var matchB = new Match(gameA, gameC);
            var matchList = new List<Match>() { matchA, matchB};

            // Act
            var stu = new Tier(matchList, 1);

            // Assert
            stu.IsFinal.Should().BeFalse();
            stu.Name.Should().Be("Semi Final");
        }

        [Fact]
        public void Contructor_MoreThanTwoMatch_ShouldNotMarkAsFinalAndNameBeTierNumber()
        {
            // Arrange
            var gameA = new Game("Game a Id", "Game a", "N64", 10, 2000, "Game a Img");
            var gameB = new Game("Game b Id", "Game b", "N64", 5, 2001, "Game b Img");
            var gameC = new Game("Game c Id", "Game c", "N64", 1, 2002, "Game c Img");
            var matchA = new Match(gameA, gameB);
            var matchB = new Match(gameA, gameC);
            var matchC = new Match(gameA, gameC);
            var matchList = new List<Match>() { matchA, matchB, matchC };

            // Act
            var stu = new Tier(matchList, 1);

            // Assert
            stu.IsFinal.Should().BeFalse();
            stu.Name.Should().Be($"Tier 1");
        }
    }
}
