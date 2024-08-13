using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchGame
{
    public interface IGame
   {
        MatchRuleEnum? MatchRule { get; }
        ResultEnum DeclareWinner(); 

    }
}
