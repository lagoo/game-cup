using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Match
    {     
        private readonly List<Game> _games = new();
        private bool _goToTieBreacker = false;        
        private Game _rightSide => _games.First();
        private Game _leftSide => _games.Last();

        public Game Winner { get; private set; }
        public Game Loser { get; private set; }

        public Match(Game rightSide, Game leftSide)
        {
            _games.Add(rightSide);
            _games.Add(leftSide);

            SetWinnerAndLoser();
        }        

        private void SetWinnerAndLoser()
        {
            if (_rightSide == _leftSide)
            {
                TieBreaker();
                return;
            }

            (Winner, Loser) = _rightSide > _leftSide ? (_rightSide, _leftSide): (_leftSide, _rightSide);
        }

        private void TieBreaker()
        {
            _goToTieBreacker = true;

            if (_rightSide.Year == _leftSide.Year)
            {
                (Winner, Loser) = (_games.OrderBy(e => e.Title).First(), _games.OrderBy(e => e.Title).Last());
                return;
            }

            (Winner, Loser) = _rightSide.Year > _leftSide.Year ? (_rightSide, _leftSide) : (_leftSide, _rightSide);            
        }

        public override string ToString()
        {
            return $"Winner: {Winner.Title}, Loser: {Loser.Title}, ReachTieBreak: {_goToTieBreacker}";
        }
    }
}
