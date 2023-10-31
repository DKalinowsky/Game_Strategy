using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PrisonersDilemma
{
    public class StrategiaMoreThan50 : Strategy
    {
        // placeholder strategy - if knownMoves are more than 50% true returns true
        // if knownMoves is empty return random true or false
        public override bool GetNextMove(List<bool> knownMoves)
        {
            if(!knownMoves.Any()){
                return random.NextDouble() >= 0.5;
            }
            else if (knownMoves.Where(x=> x.Equals(true)).Count() >= knownMoves.Count()/2){
                return true;
            }
            return false;
        }
		
        public override string ToString()
        {
            return "StrategyMoreThan50";
        }

    }
}
