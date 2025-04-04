using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_tests
{
    public class Game
    {
        private readonly List<Player> _players;
        private int _currentIndex = 0;

        public Game(List<Player> players)
        {
            _players = players;
        }

        public Player GetCurrentPlayer()
        {
            return _players[_currentIndex];
        }

        public void NextTurn()
        {
            _currentIndex = (_currentIndex + 1) % _players.Count;
        }

        public void RollDice(int roll)
        {
            if (roll != 6)
                NextTurn();
        }
    }

}
