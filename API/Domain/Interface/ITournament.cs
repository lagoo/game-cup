using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interface
{
    public interface ITournament
    {
        public Game FirstPlace { get; }
        public Game SecondPlace { get; }

        public IEnumerable<Match> Matches { get; }
    }
}
