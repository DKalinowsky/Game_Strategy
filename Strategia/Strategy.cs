using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonersDilemma
{
    public abstract class Strategy
    {
        protected Random random;
        public int TotalPoints { get; set; } // you can use this property to remember points
		
        public abstract bool GetNextMove(List<bool> knownMoves); // use this method to return your next move in game

        protected Strategy() { random = new Random(); }
    }
}
