using FluentAssertions;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.IntegrationTests.Services
{
    public class L3CompetitorsGameServiceTests
    {
        private readonly L3CompetitorsGameService _stu;

        public L3CompetitorsGameServiceTests()
        {
            _stu = new L3CompetitorsGameService(new HttpClient()
            {
                BaseAddress = new Uri("https://l3-processoseletivo.azurewebsites.net/api/")
            });
        }

        [Fact()]
        public async Task GetAvailableGames_ValidResponse_ShouldReturnAllGamesInApiEndpoint()
        {
            // Arrange & Act
            var result = await _stu.GetAvailableGames();

            // Assert
            result.Should().NotBeEmpty();
        }

        [Fact()]
        public async Task GetSelectedGames_ValidResponse_ShouldReturnGamesWithIdsSelectedApiEndpoint()
        {
            // Arrange & Act
            var result = await _stu.GetSelectedGames(new List<string>() { "/nintendo-64/the-legend-of-zelda-ocarina-of-time", "/playstation/tony-hawks-pro-skater-2" });

            // Assert
            result.Should().NotBeEmpty();
            result.Should().HaveCount(2);
            result.Any(e => e.Id == "/nintendo-64/the-legend-of-zelda-ocarina-of-time").Should().BeTrue();
        }
    }
}
