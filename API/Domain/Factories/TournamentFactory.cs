using Domain.Entities;
using Domain.Enums;
using Domain.Interface;
using System;
using System.Collections.Generic;

namespace Domain.Factories
{
    public static class TournamentFactory
    {
        public static ITournament Create(IEnumerable<Game> games, TournamentTypeEnum tournamentType)
        {
            return tournamentType switch
            {
                TournamentTypeEnum.SingleEliminationTournament => new SingleEliminationTournament(games),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
