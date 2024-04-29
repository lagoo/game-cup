using System.Collections.Generic;

namespace Application.Games.Queries.GetAvailableGames
{
    public class YearGamesDto
    {
        public YearGamesDto(int year, IEnumerable<GameDto> games)
        {
            Year = year;
            Games = games;
        }

        public int Year { get; }
        public IEnumerable<GameDto> Games { get; }
    }
}
