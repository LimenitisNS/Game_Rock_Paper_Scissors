using System;
using System.Collections.Generic;
using System.Text;

namespace Rock_Paper_Scissors
{
    public class Game
    {

        private List<Rival> rivals = new List<Rival> { };
        private List<Rival> deathsRivals = new List<Rival> { };
        private List<int> roundDethRival = new List<int> { };
        private bool endGame = false;
        private int round = 1;

        public Game(int NumberRivals)
        {
            for(int i = 0; i < NumberRivals; ++i)
            {
                Rival rival = new Rival(i);

                this.rivals.Add(rival);
            }
        }

        public void Start()
        {
            while(endGame == false)
            {
                Console.WriteLine("\nClick enter to continue\n");
                Console.ReadKey();

                NextRound();
            }

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\n");
            Console.WriteLine($"Won {rivals[0].GetRole()}");
            Console.WriteLine("\n\n++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        }

        private void NextRound()
        {
            Console.WriteLine($"_________ {this.round} round _________\n");

            StatisticsStage();

            ActionStage();

            CheckingFinalGame();

            if (deathsRivals.Count > 0)
            {
                ListDeaths();
            }

            ++round;
        }

        private void StatisticsStage()
        {
            Console.WriteLine("******** Statistics ********\n");

            for (int i = 0; i < rivals.Count; ++i)
            {
                Console.WriteLine($"Rival {rivals[i].GetID()}: Role {rivals[i].GetRole()} \n\t HP = {rivals[i].GetHealthPoints()} PP = {rivals[i].GetPowerPoint()}");
            }
        }

        private void ActionStage()
        {
            Console.WriteLine("\n<><><><><><> Action <><><><><><>\n");

            Random rival = new Random();
            int AttackRival;

            for (int i = 0; i < rivals.Count; ++i)
            {

                if (rivals[i].GetHealthPoints() <= 0)
                {
                    deathsRivals.Add(rivals[i]);
                    rivals.RemoveAt(i);
                    roundDethRival.Add(round);

                    continue;
                }

                if(GoRest(rivals[i]) == true)
                {
                    Console.WriteLine($"Rival {rivals[i].GetID()} say {rivals[i].SayPhraseAndGoRest()}");
                    continue;
                }

                AttackRival = 0;

                do
                {
                    AttackRival = rival.Next(0, rivals.Count);
                }
                while (AttackRival == i);

                if (rivals[i].AttackRivel(rivals[AttackRival]))
                {
                    rivals[AttackRival].SetHealthPoints(-(rivals[i].GetPowerPoint()));
                    Console.WriteLine($"Rival {rivals[i].GetID()} attacked rival {rivals[AttackRival].GetID()} ({rivals[i].GetRole()} x {rivals[AttackRival].GetRole()})" +
                        $" Health rival {AttackRival + 1} - {rivals[i].GetPowerPoint()} ");

                    if (rivals[AttackRival].GetHealthPoints() <= 0)
                    {
                        deathsRivals.Add(rivals[AttackRival]);
                        rivals.RemoveAt(AttackRival);
                        roundDethRival.Add(round);
                    }
                }
                else
                {
                    Console.WriteLine($"Rival {rivals[i].GetID()} attacked rival {AttackRival + 1} ({rivals[i].GetRole()} x {rivals[AttackRival].GetRole()})" +
                        $"The attack failed");
                }
            }
        }

        private bool GoRest(Rival rival)
        {
            int health = rival.GetHealthPoints();
            int power = rival.GetPowerPoint();

            if(health == 10 && power == 5)
            {
                return false;
            }

            Random ChanceGoOnRest = new Random();

            double chanceUPHealth = ChanceGoOnRest.Next(2, 5);
            double chanceUPPower = ChanceGoOnRest.Next(2, 5);

            if ((10 / health >= chanceUPHealth) || (5 / power >= chanceUPPower))
            {
                return true;
            }

            return false;
        }

        private void ListDeaths()
        {
            Console.WriteLine("\n########## Deaths ##########\n");

            for(int i = 0; i < deathsRivals.Count; ++i)
            {
                Console.WriteLine($"Round {roundDethRival[i]} rival {deathsRivals[i].GetID()}");
            }
        }

        private void CheckingFinalGame()
        {
            string roleRivals = rivals[0].GetRole();

            for (int i = 1; i < rivals.Count; ++i)
            {
                if(roleRivals != rivals[i].GetRole())
                {
                    return;
                }
            }

            this.endGame = true;
        }
    }
}
