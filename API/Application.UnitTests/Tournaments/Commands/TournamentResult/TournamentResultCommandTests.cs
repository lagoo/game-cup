using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Tournaments.Commands.TournamentResult;
using Application.UnitTests.Core;
using AutoMapper;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Tournaments.Commands.TournamentResult
{
    [Collection(nameof(QueryCollection))]
    public class TournamentResultCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICompetitorsGameService> _mockGameService;

        public TournamentResultCommandTests(QueryTestFixture fixture)
        {
            _mapper = fixture.Mapper;
            _mockGameService = new Mock<ICompetitorsGameService>();
        }

        [Fact]
        public async Task Handler_GivenValidRequest_ShouldAllAvaliableGamesGroupByYearAsync()
        {
            // Arrange
            var list = new List<CompetitorsGameDto>()
            {
                new CompetitorsGameDto()
                {
                    Id = "Game/a",
                    Title = "Game a",
                    Grade = 1,
                    Year = 2000,
                    Console = "N64",
                    ImageUrl = "Game a Img"
                },
                new CompetitorsGameDto()
                {
                    Id = "Game/b",
                    Title = "Game b",
                    Grade = 2,
                    Year = 2000,
                    Console = "N64",
                    ImageUrl = "Game b Img"
                },
                new CompetitorsGameDto()
                {
                    Id = "Game/c",
                    Title = "Game c",
                    Grade = 3,
                    Year = 2001,
                    Console = "N64",
                    ImageUrl = "Game c Img"
                },
                new CompetitorsGameDto()
                {
                    Id = "Game/d",
                    Title = "Game d",
                    Grade = 4,
                    Year = 2002,
                    Console = "N64",
                    ImageUrl = "Game d Img"
                }
            };
            var listIds = list.Select(e => e.Id).ToList();
            _mockGameService.Setup(e => e.GetSelectedGames(It.Is<List<string>>(e => e == listIds))).Returns(Task.FromResult<IEnumerable<CompetitorsGameDto>>(list));
            var sut = new TournamentResultCommand.Handler(_mockGameService.Object, _mapper);

            // Act
            var result = await sut.Handle(new TournamentResultCommand(listIds), CancellationToken.None);

            // Assert            
            result.FirstPlace.Title.Should().Be("Game d");
            result.SecondPlace.Title.Should().Be("Game c");
            _mockGameService.Verify(v => v.GetSelectedGames(It.Is<List<string>>(e => e == listIds)), Times.Once);
        }
    }
}
