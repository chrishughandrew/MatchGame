using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchGame
{
    internal interface IDeck
    {
        List<Card> BuildStandardPack();
    }
}
