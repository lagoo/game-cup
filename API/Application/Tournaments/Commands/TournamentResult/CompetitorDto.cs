using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Tournaments.Commands.TournamentResult
{
    public class CompetitorDto : IMapFrom<Game>
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Console { get; set; }
    }
}