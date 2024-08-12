using static MatchGame.Card;

namespace MatchGame
{
    public record Card(SuitEnum Suit, ValueEnum Value)
    {
        public enum ValueEnum
        {
            Ace = 1,
            _2,
            _3,
            _4,
            _5,
            _6,
            _7,
            _8,
            _9,
            _10,
            Jack,
            Queen,
            King
        }

        public enum SuitEnum
        {
            Clubs, Diamonds, Hearts, Spades
        }

    }
}