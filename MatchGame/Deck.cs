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
            return new List<Card>();
        }
    }
}
