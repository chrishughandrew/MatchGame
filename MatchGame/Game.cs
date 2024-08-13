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
        private MatchRuleEnum? _matchRule;

        public Game(IDeck gameDeck, IPlayer player1, IPlayer player2)
        {
            _gameDeck = gameDeck;
            _player1 = player1;
            _player2 = player2;
        }

        public MatchRuleEnum? MatchRule => _matchRule; 

        public ResultEnum DeclareWinner()
        {
            if (_player1.Score > _player2.Score)
                return ResultEnum.PLAYER1;
            else if (_player1.Score < _player2.Score)
                return ResultEnum.PLAYER2;
            else
                return ResultEnum.DRAW;
        }

        public string Setup(MatchRuleEnum matchRule, int numOfPacks)
        {
            _matchRule = matchRule;


            return String.Empty;
        }
    }
}
