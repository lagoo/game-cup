using Common.Extensions;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Domain.UnitTests")]
namespace Domain.Entities
{
    public class SingleEliminationTournament : ITournament
    {
        private int tier = 1;

        private Game _first;
        private Game _second;
        private readonly List<Tier> _tiers = new();

        public Game FirstPlace => _first;
        public Game SecondPlace => _second;        

        public IEnumerable<Match> Matches => _tiers?.SelectMany(e => e.Matches).ToList();

        public SingleEliminationTournament(IEnumerable<Game> games)
        {
            if (!games.Any())
                throw new ArgumentException("Lista de jogos está vazia!");

            if (!games.Count().IsPowerOfTwo() || games.Count() == 1)
                throw new ArgumentException("Lista de jogos não tem uma quantidade suficiente, não é possivel criar um torneio balanceado!");

            CreateInitialTier(games);

            Execute();
        }

        private void Execute()
        {
            if (_tiers.Last().IsFinal)
            {
                _first = _tiers.Last().Matches.First().Winner;
                _second = _tiers.Last().Matches.First().Loser;
                return;
            }

            CreateNextTier();

            Execute();
        }
        private void CreateNextTier()
        {
            List<Game> winners = _tiers.Last().Winners.ToList();

            int totalMatchToCreate = winners.Count / 2;
            int skip = 0;

            List<Match> matchs = new();

            while (totalMatchToCreate > 0)
            {
                IEnumerable<Game> games = winners.Skip(skip).Take(2).ToList();

                matchs.Add(new Match(games.First(), games.Last()));

                skip += 2;
                totalMatchToCreate--;
            }

            _tiers.Add(new Tier(matchs, tier++));
        }
        private void CreateInitialTier(IEnumerable<Game> games)
        {
            List<Game> gamesOrdered = games.OrderBy(e => e.Title).ToList();

            int initial = 0;
            int end = games.Count() - 1;
            var matchs = new List<Match>();

            while (initial < end)
            {
                matchs.Add(new Match(gamesOrdered[initial], gamesOrdered[end]));
                initial++;
                end--;
            }

            _tiers.Add(new Tier(matchs, tier++));
        }
    }

    internal class Tier
    {
        private readonly int semiFinalTier = 2;
        private readonly int finalTier = 1;
        private readonly List<Match> _matches = new();

        public string Name { get; }

        public bool IsFinal => _matches.Count == 1;
        public IEnumerable<Match> Matches => _matches;
        public IEnumerable<Game> Winners => _matches.Select(e => e.Winner);


        internal Tier(IEnumerable<Match> matches, int tier)
        {
            _matches = matches.ToList();
            Name = GetTierName(tier);
        }

        private string GetTierName(int tier)
        {
            if (_matches.Count == finalTier)
                return "Final";

            if (_matches.Count == semiFinalTier)
                return "Semi Final";

            return $"Tier {tier}";
        }


        public override string ToString()
        {
            return $"Tier: {Name}, Number Of Matches: {_matches.Count}";
        }
    }
}
