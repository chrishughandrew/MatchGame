using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchGame
{
    public class Player : IPlayer
    {
        public int Score { get; set; }

        public void AddPoints(int points)
        {
            if (points < 0) 
                throw new ArgumentOutOfRangeException();

            Score += points;
        }
    }
}
