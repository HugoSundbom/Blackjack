using System;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> Kortlek = new List<int>();

            for (int i = 2; i < 15; i++)
            {
                Kortlek.Add(i);
                if (i == 14 && Kortlek.Count < 52)
                {
                    i = 1;
                }
            }

            int playerNum = 0;

            Console.WriteLine("´Choose amount of players between 2-4");

            playerNum = Convert.ToInt32(Console.ReadLine());

            List<int> Dealer = new List<int>();

            List<int> Player1 = new List<int>();
            List<int> Player2 = new List<int>();
            List<int> Player3 = new List<int>();
            List<int> Player4 = new List<int>();

            CardDealing(Kortlek, Dealer, Player1, Player2, Player3, Player4, playerNum);

            for(int i = 0; i < Player1.Count; i++)
            {
                Console.WriteLine(Player1[i]);
            }

            for (int i = 0; i < Player2.Count; i++)
            {
                Console.WriteLine(Player2[i]);
            }

            for (int i = 0; i < Player3.Count; i++)
            {
                Console.WriteLine(Player3[i]);
            }

            for (int i = 0; i < Player4.Count; i++)
            {
                Console.WriteLine(Player4[i]);
            }

            int dealerCount = 0;

            while(dealerCount < 22)
            {

            }

        }

        static void CardDealing(List<int>Kortlek, List<int>Dealer, List<int>Player1, List<int> Player2, List<int> Player3, List<int> Player4, int playerNum)
        {

            Random rand = new Random();

            int rnd = 0;

            for (int i = 0;i < 2; i++)
            {
                if(rnd > 11)
                {

                }
                rnd = rand.Next(0, Kortlek.Count);
                if(Kortlek[rnd] > 11) { Kortlek[rnd] = 10; }
                Dealer.Add(Kortlek[rnd]);
                Kortlek.Remove(Kortlek[rnd]);

                rnd = rand.Next(0, Kortlek.Count);
                if (Kortlek[rnd] > 11) { Kortlek[rnd] = 10; }
                Player1.Add(Kortlek[rnd]);
                Kortlek.Remove(Kortlek[rnd]);

                rnd = rand.Next(0, Kortlek.Count);
                if (Kortlek[rnd] > 11) { Kortlek[rnd] = 10; }
                Player2.Add(Kortlek[rnd]);
                Kortlek.Remove(Kortlek[rnd]);

                if(playerNum > 2)
                {
                    rnd = rand.Next(0, Kortlek.Count);
                    if (Kortlek[rnd] > 11) { Kortlek[rnd] = 10; }
                    Player3.Add(Kortlek[rnd]);
                    Kortlek.Remove(Kortlek[rnd]);

                    if(playerNum == 4)
                    {
                        rnd = rand.Next(0, Kortlek.Count);
                        if (Kortlek[rnd] > 11) { Kortlek[rnd] = 10; }
                        Player4.Add(Kortlek[rnd]);
                        Kortlek.Remove(Kortlek[rnd]);
                    }
                }
            }
        }
        static int plus (List<int> cards)
        {
            int sum = 0;
            for(int i = 0; i < cards.Count; i++)
            {
                sum = sum + cards[i];
            }
            return sum;
        }
    }
}
