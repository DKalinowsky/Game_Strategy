using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace PrisonersDilemma
{
    public class StrategiaSensible : Strategy
    {
        // placeholder strategy - Sensible Cooperates until its opponent has defected once, and then defects for the rest of the game.
        public override bool GetNextMove(List<bool> knownMoves)
        {
            if(!knownMoves.Any())
            {
                return true;
            }
            else if (!knownMoves.Contains(false))
            {
                return true;
            }
            else return false;
        }
		
        public override string ToString()
        {
            return "StrategySensible";
        }

    }
}
