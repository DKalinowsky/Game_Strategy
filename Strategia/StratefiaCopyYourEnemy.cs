using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PrisonersDilemma
{
    public class StratefiaCopyYourEnemy : Strategy
    {
        // placeholder strategy - CopyYourEnemy (Cooperates on the first round and imitates its opponent's previous move thereafter.)
        public override bool GetNextMove(List<bool> knownMoves)
        {
            if(!knownMoves.Any()){
                return true;
            }
            else {
                return knownMoves.Last();
            }
        }
		
        public override string ToString()
        {
            return "StrategyCOOPCopyYourEnemy";
        }

    }
}
