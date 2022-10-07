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

            Console.WriteLine("Choose amount of players between 2-4");

            playerNum = Convert.ToInt32(Console.ReadLine());

            List<int> Dealer = new List<int>();

            List<int> Player1 = new List<int>();
            List<int> Player2 = new List<int>();
            List<int> Player3 = new List<int>();
            List<int> Player4 = new List<int>();

            CardDealing(Kortlek, Dealer, Player1, Player2, Player3, Player4, playerNum);
            //Eventuellt ändra så man kan spela ensam

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
            String p1Tjock = "n";
            String p2Tjock = "n";
            String p3Tjock = "n";
            String p4Tjock = "n";

            while (dealerCount < 22)
            {
                if(p1Tjock == "n")
                {
                    int player1Sum = plus(Player1);
                    if (player1Sum == 21)
                    {
                        Console.WriteLine("player1 vann");
                    }
                    else if (player1Sum > 21)
                    {
                        Console.WriteLine("player1 är tjock");

                        p1Tjock = "y";
                    }
                }
                if (p2Tjock == "n")
                {

                    int player2Sum = plus(Player2);
                    if (player2Sum == 21)
                    {
                        Console.WriteLine("Player 2 vann");
                    }
                    else if (player2Sum > 21)
                    {
                        Console.WriteLine("player1 är tjock");

                        p1Tjock = "y";
                    }
                }
                if (p3Tjock == "n")
                {
                    int player3Sum = plus(Player3);
                    if (playerNum > 2)
                    {
                        if (player3Sum == 21)
                        {
                            Console.WriteLine("player3 vann");
                        }
                    }
                    else if (player3Sum > 21)
                    {
                        Console.WriteLine("player1 är tjock");

                        p1Tjock = "y";
                    }
                }

                if (p4Tjock == "n")
                {
                    int player4Sum = plus(Player3);
                    if (playerNum == 4)
                    {
                        if (player4Sum == 21)
                        {
                            Console.WriteLine("player4 vann");
                        }
                    }
                    else if (player4Sum > 21)
                    {
                        Console.WriteLine("player1 är tjock");

                        p1Tjock = "y";
                    }
                }
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
                if(sum > 21 && cards[i] == 11)
                {
                    sum -= 10;
                }
            }
            return sum;
        }
    }
}
