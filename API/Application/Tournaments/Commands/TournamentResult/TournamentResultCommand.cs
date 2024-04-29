using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Factories;
using Domain.Interface;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Tournaments.Commands.TournamentResult
{
    public class TournamentResultCommand : IRequest<TournamentResultVm>
    {
        public TournamentResultCommand(IEnumerable<string> gameIds)
        {
            GameIds = gameIds;
        }

        public IEnumerable<string> GameIds { get; }

        public class Handler : IRequestHandler<TournamentResultCommand, TournamentResultVm>
        {
            private readonly ICompetitorsGameService _competitorsGameService;
            private readonly IMapper _mapper;

            public Handler(ICompetitorsGameService competitorsGameService, IMapper mapper)
            {
                _competitorsGameService = competitorsGameService;
                _mapper = mapper;
            }

            public async Task<TournamentResultVm> Handle(TournamentResultCommand request, CancellationToken cancellationToken)
            {
                IEnumerable<CompetitorsGameDto> selectedGames = await _competitorsGameService.GetSelectedGames(request.GameIds);

                IEnumerable<Game> games = selectedGames.Select(e => new Game(e.Id, e.Title, e.Console, e.Grade, e.Year, e.ImageUrl))
                                                       .ToList();

                ITournament tournament = TournamentFactory.Create(games, TournamentTypeEnum.SingleEliminationTournament);

                return new TournamentResultVm(_mapper.Map<CompetitorDto>(tournament.FirstPlace), _mapper.Map<CompetitorDto>(tournament.SecondPlace), _mapper.Map<IEnumerable<MatchDto>>(tournament.Matches));                
            }
        }
    }
}
