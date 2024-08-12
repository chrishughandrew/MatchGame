using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchGame
{
    public class Deck : IDeck
    {
        public List<Card> BuildStandardPack()
        {
            var standardDeck = from suit in Enum.GetValues<Card.SuitEnum>()
                               from value in Enum.GetValues<Card.ValueEnum>()
                               select new Card(suit, value);

            return standardDeck.ToList();
        }
    }
}
