using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonersDilemma
{
    public class StrategiaRandom : Strategy
    {
        // placeholder strategy - random (always return random true of false)
        public override bool GetNextMove(List<bool> knownMoves)
        {
            return random.NextDouble() >= 0.5;
        }
		
        public override string ToString()
        {
            return "StrategyRandom";
        }

    }
}
