using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Tournaments.Commands.TournamentResult
{
    public class MatchDto : IMapFrom<Match>
    {
        public CompetitorDto Winner { get; set; }
        public CompetitorDto Loser { get; set; }
    }
}