using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Games.Queries.GetAvailableGames
{
    public class GetAvailableGamesQuery : IRequest<AvailableGamesVm>
    {
        public class Handler : IRequestHandler<GetAvailableGamesQuery, AvailableGamesVm>
        {
            private readonly ICompetitorsGameService _competitorsGameService;
            private readonly IMapper _mapper;

            public Handler(ICompetitorsGameService competitorsGameService, IMapper mapper)
            {
                _competitorsGameService = competitorsGameService;
                _mapper = mapper;
            }

            public async Task<AvailableGamesVm> Handle(GetAvailableGamesQuery request, CancellationToken cancellationToken)
            {
                var competitorGames = await _competitorsGameService.GetAvailableGames();

                IEnumerable<YearGamesDto> dto = competitorGames.GroupBy(cg => cg.Year)
                                                                .OrderByDescending(e => e.Key)
                                                                .Select(cg => new YearGamesDto(cg.Key, _mapper.Map<IEnumerable<GameDto>>(cg)))
                                                                .ToList();

                return new AvailableGamesVm(dto);
            }
        }
    }
}
