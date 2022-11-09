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
            Console.WriteLine("kort 1 och 2 tillhör player 1, kort 3 och 4 tillhör player 2 osv.");

            //Spelar listor
            List<int> Dealer = new List<int>();
            List<int> Player1 = new List<int>();
            List<int> Player2 = new List<int>();
            List<int> Player3 = new List<int>();
            List<int> Player4 = new List<int>();

            string p1Continue = "y";
            string p2Continue = "y";
            string p3Continue = "y";
            string p4Continue = "y";

            CardDealing(Kortlek, Dealer, Player1, Player2, Player3, Player4, playerNum, 2);

            for (int i = 0; i < Player1.Count; i++)
            {
                Console.WriteLine(Player1[i]);
            }

            Console.WriteLine("");

            for (int i = 0; i < Player2.Count; i++)
            {
                Console.WriteLine(Player2[i]);
            }

            Console.WriteLine("");

            for (int i = 0; i < Player3.Count; i++)
            {
                Console.WriteLine(Player3[i]);
            }

            Console.WriteLine("");

            for (int i = 0; i < Player4.Count; i++)
            {
                Console.WriteLine(Player4[i]);
            }

            int dealerCount = Plus(Dealer);

            String p1Tjock = "n";
            String p2Tjock = "n";
            String p3Tjock = "n";
            String p4Tjock = "n";

            // skapar dessa utanför looparna så vi kan använda dem
            int player1Sum = 0;
            int player2Sum = 0;
            int player3Sum = 0;
            int player4Sum = 0;

            Console.WriteLine("");
            
            Console.WriteLine("Dealern har: \n" + Dealer[0] + "\n" + Dealer[1]);

            while (dealerCount < 22)
            {
                Console.WriteLine("");

                //Player 1
                if (p1Tjock == "n" && p1Continue == "y")
                {
                    Console.WriteLine("PLAYER 1");
                    player1Sum = Plus(Player1);
                    if (player1Sum == 21)
                    {
                        Console.WriteLine("player1 vann");
                    }
                    else if (player1Sum > 21)
                    {
                        Console.WriteLine("player1 är tjock");

                        p1Tjock = "y";
                    }
                    else if(player1Sum < 21)
                    {
                        Console.WriteLine("Vill player 1 ha ett till kort? y/n");
                        p1Continue = Console.ReadLine();
                        if (p1Continue == "y")
                        {
                            Player1.Add(addSingleCard(Kortlek));
                            player1Sum = Plus(Player1);
                            Console.WriteLine("Player 1 har:");
                            for (int i = 0; i < Player1.Count; i++)
                            {
                                Console.WriteLine(Player1[i]);
                            }
                            if(player1Sum > 21)
                            {
                                Console.WriteLine("Player1 är tjock");
                                p1Continue = "n";
                            }
                            else if(player1Sum == 21)
                            {
                                Console.WriteLine("Player 1 har 21");
                                p1Continue = "n";
                            }
                        }
                    }

                }

                Console.WriteLine("");

                //Player 2
                if (p2Tjock == "n" && p2Continue == "y")
                {
                    Console.WriteLine("PLAYER 2");
                    player2Sum = Plus(Player2);
                    if (player2Sum == 21)
                    {
                        Console.WriteLine("Player 2 vann");
                    }
                    else if (player2Sum > 21)
                    {
                        Console.WriteLine("player 2 är tjock");

                        p2Tjock = "y";
                    }
                    else if (player2Sum < 21)
                    {
                        Console.WriteLine("Vill player 2 ha ett till kort? y/n");
                        p2Continue = Console.ReadLine();
                        if (p2Continue == "y")
                        {
                            Player2.Add(addSingleCard(Kortlek));
                            player2Sum = Plus(Player2);
                            Console.WriteLine("Player 2 har:");
                            for (int i = 0; i < Player2.Count; i++)
                            {
                                Console.WriteLine(Player2[i]);
                            }
                            if (player2Sum > 21)
                            {
                                Console.WriteLine("Player2 är tjock");
                                p2Continue = "n";
                            }
                            else if (player2Sum == 21)
                            {
                                Console.WriteLine("Player 2 fick 21");
                                p2Continue = "n";
                            }
                        }
                    }
                }

                Console.WriteLine("");

                //player 3
                if (p3Tjock == "n" && p3Continue == "y")
                {
                    player3Sum = Plus(Player3);
                    if (playerNum > 2)
                    {
                        Console.WriteLine("PLAYER 3");
                        if (player3Sum == 21)
                        {
                            Console.WriteLine("player3 vann");
                        }

                        else if (player3Sum > 21)
                        {
                            Console.WriteLine("player 3 är tjock");

                            p3Tjock = "y";
                        }
                        else if (player3Sum < 21)
                        {
                            Console.WriteLine("Vill player 3 ha ett till kort? y/n");
                            p3Continue = Console.ReadLine();
                            if (p3Continue == "y")
                            {
                                Player3.Add(addSingleCard(Kortlek));
                                player3Sum = Plus(Player3);
                                Console.WriteLine("Player 3 har:");
                                for (int i = 0; i < Player3.Count; i++)
                                {
                                    Console.WriteLine(Player3[i]);
                                }
                                if (player3Sum > 21)
                                {
                                    Console.WriteLine("Player3 är tjock");
                                    p3Continue = "n";
                                }
                                else if (player3Sum == 21)
                                {
                                    Console.WriteLine("Player 3 fick 21");
                                    p3Continue = "n";
                                }
                            }
                        }
                    }
                    else
                    {
                        p3Continue = "n";
                    }
                }

                Console.WriteLine("");

                //Player 4
                if (p4Tjock == "n" && p4Continue == "y")
                {
                    player4Sum = Plus(Player4);
                    if (playerNum > 3)
                    {
                        Console.WriteLine("PLAYER 4");
                        if (player4Sum == 21)
                        {
                            Console.WriteLine("player4 vann");
                        }
                        else if (player4Sum > 21)
                        {
                            Console.WriteLine("player 4 är tjock");
                            p4Tjock = "y";
                        }
                        else if (player4Sum < 21)
                        {
                            Console.WriteLine("Vill player 4 ha ett till kort? y/n");
                            p4Continue = Console.ReadLine();
                            if(p4Continue == "y")
                            {
                                Player4.Add(addSingleCard(Kortlek));
                                player4Sum = Plus(Player4);
                                Console.WriteLine("Player 4 har:");
                                for(int i = 0; i < Player4.Count; i++)
                                {
                                    Console.WriteLine(Player4[i]);
                                }
                                if (player4Sum > 21)
                                {
                                    Console.WriteLine("Player4 är tjock");
                                    p1Continue = "n";
                                }
                                else if (player4Sum == 21)
                                {
                                    Console.WriteLine("Player 4 fick 21");
                                    p4Continue = "n";
                                }
                            }
                        }
                    }
                    else
                    {
                        p4Continue = "n";
                    }
                }

                if (p1Continue == "n" && p2Continue == "n" && p3Continue == "n" && p4Continue == "n")
                {
                    break;
                }

                //Dealer
                if (dealerCount < 17)
                {
                    Dealer.Add(addSingleCard(Kortlek));
                    Console.WriteLine("Dealern drar en " + Dealer[Dealer.Count - 1]);
                    dealerCount = Plus(Dealer);
                }
                else
                {
                    Console.WriteLine("Dealern drar inget kort");
                }
                Console.WriteLine("Dealern har:");
                for (int i = 0; i < Dealer.Count; i++)
                {
                    Console.WriteLine(Dealer[i]);
                }
            }
            if(dealerCount > 21)
            {
                Console.WriteLine("Grattis, dealern är tjock");
            }

            Console.WriteLine("");
            
            Console.WriteLine("Player 1 har " + player1Sum + "\nPlayer 2 har " + player2Sum);
            if(playerNum > 2)
            {
                Console.WriteLine("Player 3 har " + player3Sum);
                if(playerNum > 3)
                {
                    Console.WriteLine("Player 4 har " + player4Sum);
                }
            }
            Console.WriteLine("Breakcheck");
        }
        static void CardDealing(List<int> Kortlek, List<int> Dealer, List<int> Player1, List<int> Player2, List<int> Player3, List<int> Player4, int playerNum, int numOfDeals)
        {

            Random rand = new Random();

            int rnd = 0;

            for (int i = 0; i < numOfDeals; i++)
            {
                rnd = rand.Next(0, Kortlek.Count);
                if (Kortlek[rnd] > 11) { Kortlek[rnd] = 10; }
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

                if (playerNum > 2)
                {
                    rnd = rand.Next(0, Kortlek.Count);
                    if (Kortlek[rnd] > 11) { Kortlek[rnd] = 10; }
                    Player3.Add(Kortlek[rnd]);
                    Kortlek.Remove(Kortlek[rnd]);

                    if (playerNum == 4)
                    {
                        rnd = rand.Next(0, Kortlek.Count);
                        if (Kortlek[rnd] > 11) { Kortlek[rnd] = 10; }
                        Player4.Add(Kortlek[rnd]);
                        Kortlek.Remove(Kortlek[rnd]);
                    }
                }
            }
        }
        static int Plus(List<int> cards)
        {
            int sum = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                sum = sum + cards[i];
                if (sum > 21 && cards[i] == 11)
                {
                    sum -= 10;
                }
            }
            return sum;
        }
        static int addSingleCard(List<int> Kortlek)
        {
            int card = 0;
            Random rand = new Random();
            int rnd = rand.Next(0, Kortlek.Count);
            if (Kortlek[rnd] > 11) { Kortlek[rnd] = 10; }
            card = Kortlek[rnd];
            Kortlek.Remove(Kortlek[rnd]);

            return card;
        }
    }
}
