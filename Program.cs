namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main()
        {
            PlayGame();
        }

        private static void PlayGame()
        {
            Console.WriteLine("|--- Welcome to Tic Tac Toe ---|");
            Console.WriteLine("Do you want to play:\n" +
            "0) To Exit\n" +
            "1) Human vs Human\n" +
            "2) Human vs CPU\n");
            string? input = Console.ReadLine();
            
            switch (input)
            {
                case "0":
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;
                case "1":
                    HumanVsHuman.GameStart();
                    break;
                case "2":
                    Console.WriteLine("> You have chosen to fight the CPU.");
                    HumanVsCPU.GameStart();
                    break;
                default:
                    Console.WriteLine("> This is not a valid number, please try again.");
                    Main();
                    break;
            }
        }
    }
}

/* AI basic with random

1. Check which positions are left
So you have to check which positions does not have an X or an O from 1-9
2. Randomly put an O on those leftover position

*/