using Application.Common.Mappings;
using Application.Common.Models;

namespace Application.Games.Queries.GetAvailableGames
{
    public class GameDto : IMapFrom<CompetitorsGameDto>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Console { get; set; }
    }
}