using Application.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICompetitorsGameService
    {
        Task<IEnumerable<CompetitorsGameDto>> GetAvailableGames();
        Task<IEnumerable<CompetitorsGameDto>> GetSelectedGames(IEnumerable<string> ids);
    }
}
