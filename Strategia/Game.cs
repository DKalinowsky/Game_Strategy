using System;
using System.Collections.Generic;
using System.Text;

namespace PrisonersDilemma
{
    public class Game
    {
        private Player player1, player2;
        private int rounds = 30;    // how many rounds
        private int score1 = 10;    // both players cooperate
        private int score2 = 15;    // one player betrays - winner
        private int score3 = -10;   // one player betrays - loser
        private int score4 = 0;     // both players betray
                                    // note: it can be shown mathematically that this game is non-trivial if: 
                                    // 1) score2 > score1 > score4 > score3, AND
                                    // 2) 2*score1 > score2 + score3


        public void RunTournament()
        {
            player1 = new Player();
            player2 = new Player();
            List<Strategy> strategiesOfFirstPlayer = new List<Strategy>() { new StrategyAlwaysTrue(),new StrategyAlwaysFalse(),
             new StrategiaMoreThan50(), new StratefiaCopyYourEnemy(),new StrategiaCopyYourEnemy2(),new StrategiaRandom(),new StrategiaSensible() };
            List<Strategy> strategiesOfSecondPlayer = new List<Strategy>() { new StrategyAlwaysTrue(),new StrategyAlwaysFalse(),
             new StrategiaMoreThan50(), new StratefiaCopyYourEnemy(),new StrategiaCopyYourEnemy2(),new StrategiaRandom(),new StrategiaSensible() };
            int noOfTimes = 2;
            foreach(Strategy strategy1 in strategiesOfFirstPlayer)
            {
                player1.CurrentStrategy = strategy1;
                //poniewaz kazda strategia ma zagrac 2 razy (tak to rozumiem)
                for(int j=0; j< noOfTimes; j++)
                {
                    foreach (Strategy strategy2 in strategiesOfSecondPlayer)
                        {
                            // jak ustawic strategie obu graczy?
                            player2.CurrentStrategy = strategy2;
                            PlayOneGame();
                            player2.CurrentStrategy.TotalPoints +=player2.Score;
                            // jak zarejestrowac wyniki?
                        }
                }
                player1.CurrentStrategy.TotalPoints +=player1.Score;
            }

            //mozemy tak zrobic bo gracz pierwszy i 2 posiadaja taka sama liczbe strategii (nie jest to dobre wyjscie ale w tym przypadku dzialajace)
            for(int i = 0 ; i < strategiesOfFirstPlayer.Count; i ++){
                    Console.WriteLine($"Wszystkie punkty dla {strategiesOfFirstPlayer[i]}: {strategiesOfFirstPlayer[i].TotalPoints + strategiesOfSecondPlayer[i].TotalPoints} \n");
            }
            // tutaj prosze wyswietlic na ekran wyniki turnieju, w formacie:
            // strategiaA   900 punktow
            // strategiaB   800 punktow
            // strategiaC   700 punktow
            // itd.

        }

        private void PlayOneGame()
        {
            for (int i = 0; i < rounds; i++)
            {
                bool move1 = player1.GetNextMove();
                bool move2 = player2.GetNextMove();

                if (move1 && move2) // both players cooperated
                {
                    // update score
                    player1.Score += score1;
                    player2.Score += score1;
                    // update players' knowledge about their partner
                    player1.PartnerMoves.Add(true);
                    player2.PartnerMoves.Add(true);
                }
                else if (move1) // player2 betrayed player1
                {
                    player1.Score += score3;
                    player2.Score += score2;
                    player1.PartnerMoves.Add(false);
                    player2.PartnerMoves.Add(true);
                }
                else if (move2) // player1 betrayed player2
                {
                    player1.Score += score2;
                    player2.Score += score3;
                    player1.PartnerMoves.Add(true);
                    player2.PartnerMoves.Add(false);
                }
                else // both players betrayed
                {
                    player1.Score += score4;
                    player2.Score += score4;
                    player1.PartnerMoves.Add(false);
                    player2.PartnerMoves.Add(false);
                }
            }
            Console.WriteLine(player1.CurrentStrategy + "\t" + player1.Score + " points");
            Console.WriteLine(player2.CurrentStrategy + "\t" + player2.Score + " points");
            Console.WriteLine();
        }

    }
}
