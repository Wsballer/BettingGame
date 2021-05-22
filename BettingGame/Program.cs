using System;

namespace BettingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = 0.75;
            Guy player = new Guy() { Cash = 100, Name = "The player" };

            Console.WriteLine("Welcome to the casino. The odds are 0.75");

            while (player.Cash > 0)
            {
                player.WriteMyInfo();
                Console.Write("How much do you want to bet: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "") return;
                if (int.TryParse(howMuch, out int amount))
                {
                    int pot = amount * 2;
                    double houseBet = random.NextDouble();
                    if (houseBet > odds)
                    {
                        Console.WriteLine("You win " + pot);
                        player.ReceiveCash(amount);
                    }
                    else
                    {
                        Console.WriteLine("Bad luck, you lose.");
                        player.GiveCash(amount);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an amount (or hit enter to exit).");
                }
            }
            Console.WriteLine("The house always wins.");
        }
    }
}
