class HumanVsHuman : TicTacToeParent
{
    public static new void GameStart()
    {
        Console.WriteLine("Turn " + playTurn);
        Board(); // Draw board
        if (CheckWinner() == 1) // Check if the winner has been found.
        {
            Console.WriteLine("Game has ended.");
            Console.WriteLine("Player " + player + " has won! \n");
            Environment.Exit(0);
        }
        else if (playTurn == 9)
        {
            Console.WriteLine("Game has ended.");
            Console.WriteLine("It's a draw! \n");
            Environment.Exit(0);
        }
        else
        {
            player = (player != 1) ? 1 : 2; // if not 1 then put 1, because the game starts with player 1
            Console.WriteLine("You are playing as player number => " + player);
            Choice(); // Make your choice
        }
    }

    private static new void Choice()
    {
        int i = 0;
        Console.Write("(0 = Exit), Type a number between 1-9: " + choice);
        choice = Console.ReadLine();
        Console.WriteLine("\n");
        
        if(choice == "0")
        {
            Console.WriteLine(choice + " Exiting...");
            Environment.Exit(0);
        }
        
        if (choice != "X" && choice != "O")
        {
            foreach (string c in positions)
            {
                i++;
                if (c == choice)
                {
                    if(player == 1)
                    {   
                        positions[i-1] = "X";
                    }
                    else if(player == 2)
                    {
                        positions[i-1] = "O";
                    }
                    playTurn++;
                    choice = "";
                    GameStart();
                }
            }
            ResetChoice();
        }
        ResetChoice();
    }

    public static new void ResetChoice()
    {
        Console.WriteLine(choice + " is not a valid number, please choose a valid number.");
        choice = ""; // Reset choice to nothing
        Choice();
    }
}