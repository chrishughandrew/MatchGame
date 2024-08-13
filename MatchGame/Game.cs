using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchGame
{
    public class Game : IGame
    {
        private readonly IDeck _gameDeck;
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public Game(IDeck gameDeck, IPlayer player1, IPlayer player2)
        {
            _gameDeck = gameDeck;
            _player1 = player1;
            _player2 = player2;
        }

        public ResultEnum DeclareWinner()
        {
            return ResultEnum.DRAW;
        }
    }
}
