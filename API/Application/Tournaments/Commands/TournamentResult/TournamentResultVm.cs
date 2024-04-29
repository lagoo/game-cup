using System.Collections.Generic;

namespace Application.Tournaments.Commands.TournamentResult
{
    public class TournamentResultVm
    {
        public TournamentResultVm(CompetitorDto firstPlace, CompetitorDto secondPlace, IEnumerable<MatchDto> matchDtos)
        {
            FirstPlace = firstPlace;
            SecondPlace = secondPlace;
            Matches = matchDtos;
        }

        public CompetitorDto FirstPlace { get; }
        public CompetitorDto SecondPlace { get; }
        public IEnumerable<MatchDto> Matches { get; }
    }
}