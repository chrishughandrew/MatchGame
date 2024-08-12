using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchGame
{
    public class Deck : IDeck
    {
        private List<Card> _cards;

        public Deck(int numOfPacks=1)
        {
            _cards = BuildMultiplePacks(numOfPacks);
        }

        public List<Card> Cards => _cards;


        //Methods
        public List<Card> BuildStandardPack()
        {
            var standardDeck = from suit in Enum.GetValues<Card.SuitEnum>()
                               from value in Enum.GetValues<Card.ValueEnum>()
                               select new Card(suit, value);

            return standardDeck.ToList();
        }

        /// <summary>
        ///     A deck method that will return a collection of multiple standard
        ///     52 card packs to the factor provided by the input. 
        /// </summary>
        /// <param name="numOfPacks">Should always be 1 or more to return a useful ouput</param>
        /// <returns>The collection of playing cards</returns>
        public List<Card> BuildMultiplePacks(int numOfPacks)
        {
            if (numOfPacks <= 0)
                throw new ArgumentOutOfRangeException();

            List<Card> packs = new();
            for (int i = 0; i < numOfPacks; i++)
            {
                packs.AddRange(BuildStandardPack());
            }

            return packs;
        }

        public void Shuffle()
        {
            Random rnd = new();
            _cards = _cards
                .OrderBy(_ => rnd.Next())
                .ToList();
        }

        public Card TakeCard()
        {
            Card topCard = _cards.FirstOrDefault();
            if (topCard != null)
            {
                _cards.Remove(topCard);
            }
            return topCard;
        }
    }
}
