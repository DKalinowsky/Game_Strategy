using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace PrisonersDilemma
{
    public class StrategiaCopyYourEnemy2 : Strategy
    {
        // placeholder strategy - CopyYourEnemy2 (Defects on the first round and imitates its opponent's previous move thereafter.)
        public override bool GetNextMove(List<bool> knownMoves)
        {
            if(!knownMoves.Any()){
                return false;
            }
            else {
                return knownMoves.Last();
            }
        }
		
        public override string ToString()
        {
            return "StrategyBetrayCopyYourEnemy";
        }

    }
}
