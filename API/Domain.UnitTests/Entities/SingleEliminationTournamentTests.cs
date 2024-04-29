using Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.UnitTests.Entities
{
    public class SingleEliminationTournamentTests
    {
        [Fact]
        public void Contructor_ListOfGamesEmpty_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var games = new List<Game>();

            // Act & Assert
            var exeption = Assert.Throws<ArgumentException>(() => new SingleEliminationTournament(games));
            exeption.Message.Should().Be("Lista de jogos está vazia!");
        }

        [Fact]
        public void Contructor_ListOfGamesNotPowerOfTwo_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var games = new List<Game>() { new Game("Game a Id", "Game a", "N64", 1, 2000, "Game a img") };

            // Act & Assert
            var exeption = Assert.Throws<ArgumentException>(() => new SingleEliminationTournament(games));
            exeption.Message.Should().Be("Lista de jogos não tem uma quantidade suficiente, não é possivel criar um torneio balanceado!");
        }

        [Fact]
        public void Contructor_ValidListOfGames_ShouldFindFirstAndSecondPlace()
        {
            // Arrange
            var first = new Game("Game h Id", "Game h", "N64", 8, 2007, "Game h img");
            var second = new Game("Game f Id", "Game f", "N64", 6, 2005, "Game f img");

            var games = new List<Game>() {
                new Game("Game a Id", "Game a", "N64", 1, 2000, "Game a img"),
                new Game("Game b Id", "Game b", "N64", 2, 2001, "Game b img"),
                new Game("Game c Id", "Game c", "N64", 3, 2002, "Game c img"),
                new Game("Game d Id", "Game d", "N64", 4, 2003, "Game d img"),
                new Game("Game e Id", "Game e", "N64", 5, 2004, "Game e img"),
                second,
                new Game("Game g Id", "Game g", "N64", 7, 2006, "Game g img"),
                first,
            };

            // Act
            var tournament = new SingleEliminationTournament(games);

            // Assert  
            tournament.FirstPlace.Should().Be(first);
            tournament.SecondPlace.Should().Be(second);
            tournament.Matches.Count().Should().Be(7);
        }
    }
}
