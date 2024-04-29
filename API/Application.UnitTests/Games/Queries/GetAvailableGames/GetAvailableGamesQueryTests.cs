using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Games.Queries.GetAvailableGames;
using Application.UnitTests.Core;
using AutoMapper;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Games.Queries.GetAvailableGames
{
    [Collection(nameof(QueryCollection))]
    public class GetAvailableGamesQueryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICompetitorsGameService> _mockGameService;

        public GetAvailableGamesQueryTests(QueryTestFixture fixture)
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
                    Grade = 1,
                    Year = 2000,
                    Console = "N64",
                    ImageUrl = "Game b Img"
                },
                new CompetitorsGameDto()
                {
                    Id = "Game/c",
                    Title = "Game c",
                    Grade = 1,
                    Year = 2001,
                    Console = "N64",
                    ImageUrl = "Game c Img"
                },
                new CompetitorsGameDto()
                {
                    Id = "Game/d",
                    Title = "Game d",
                    Grade = 1,
                    Year = 2002,
                    Console = "N64",
                    ImageUrl = "Game d Img"
                }
            };
            _mockGameService.Setup(e => e.GetAvailableGames()).Returns(Task.FromResult<IEnumerable<CompetitorsGameDto>>(list));
            var sut = new GetAvailableGamesQuery.Handler(_mockGameService.Object, _mapper);

            // Act
            var result = await sut.Handle(new GetAvailableGamesQuery(), CancellationToken.None);

            // Assert            
            result.Years.Should().HaveCount(3);
            result.Years.First().Year.Should().Be(2002);
            _mockGameService.Verify(v => v.GetAvailableGames(), Times.Once);
        }
    }
}
