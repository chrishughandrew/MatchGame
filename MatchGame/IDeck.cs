using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchGame
{
    public interface IDeck
    {
        bool HasCards { get; }
        List<Card> BuildStandardPack();
        List<Card> BuildMultiplePacks(int numOfPacks);
        void Shuffle();
        Card TakeCard();

    }
}
