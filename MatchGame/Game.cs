using System;
using System.Collections.Generic;
using System.IO;
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
        private MatchRuleEnum _matchRule;
        private readonly Stack<Card> _pile = new();

        public Game(IDeck gameDeck, IPlayer player1, IPlayer player2)
        {
            _gameDeck = gameDeck;
            _player1 = player1;
            _player2 = player2;
        }

        public MatchRuleEnum MatchRule => _matchRule; 

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
            _gameDeck.BuildMultiplePacks(numOfPacks);
            _gameDeck.Shuffle(); 

            string setupInfo = 
                matchRule == MatchRuleEnum.FULL && numOfPacks == 1
                ? "You can play with this setup, but nobody ever wins!"
                : "The game is ready to play.";

            return setupInfo;
        }

        public bool Play()
        {
            while(_gameDeck.HasCards)
            {
                //Add game logic here: 
                //- create pile
                Card topPileCard = StartNewPile();
                Console.WriteLine($"\nNEW PILE: {topPileCard}");
                //- play through the deck until there's a match
                //- repeat
            }

            //game over
            return !_gameDeck.HasCards;
        }

        private Card StartNewPile()
        {
            _pile.Clear();
            Card firstCard = _gameDeck.TakeCard(); //TODO: handle - this could be null. 
            _pile.Push(firstCard);
            return firstCard;
        }

        private void AddCardToPile(Card nextCard)
        {
            _pile.Push(nextCard);
        }

        private void PlayToPileUntilMatch(Card topPileCard) //TODO: Questionable signature.
        {
            while (_gameDeck.HasCards)
            {
                Thread.Sleep(100);
                Card nextCard = _gameDeck.TakeCard();
                Console.WriteLine(nextCard);


                bool cardsMatch = true;
                //bool cardsMatch = IsMatch(topPileCard, nextCard);

                //add to pile here                
                AddCardToPile(nextCard);
                topPileCard = nextCard;

                if (cardsMatch)
                {
                    //random player delcares match
                    //add points

                    break;
                }
            }
        }

        private bool IsMatch(Card topOfPile, Card nextCard)
        {
            bool isMatch;
            switch (_matchRule)
            {
                case MatchRuleEnum.VALUE:
                    isMatch = topOfPile.Value == nextCard.Value;
                    break;
                case MatchRuleEnum.SUIT:
                    isMatch = topOfPile.Suit == nextCard.Suit;
                    break;
                case MatchRuleEnum.FULL:
                    isMatch = topOfPile == nextCard;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return isMatch;
        }

    }
}
