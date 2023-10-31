using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonersDilemma
{
    public class Player
    {
        public Strategy CurrentStrategy { get; set; } // the algorithm used to make moves
        public List<bool> PartnerMoves { get; set; } // true means cooperation, false means betrayal
        public int Score { get; set; } // game score

        public Player()
        {
            PartnerMoves = new List<bool>();
        }
        public bool GetNextMove()
        {
            return CurrentStrategy.GetNextMove(PartnerMoves);
        }

    }
}
