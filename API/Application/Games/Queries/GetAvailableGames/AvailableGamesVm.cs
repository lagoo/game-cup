using System.Collections.Generic;

namespace Application.Games.Queries.GetAvailableGames
{
    public class AvailableGamesVm
    {
        public AvailableGamesVm(IEnumerable<YearGamesDto> years)
        {
            Years = years;
        }

        public IEnumerable<YearGamesDto> Years { get; }
    }
}