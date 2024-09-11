using System;
using System.Collections.Generic;

class HumanVsCPU : TicTacToeParent
{
    public static List<string> occupied_list = new List<string>();

    public static new void GameStart()
    {
        Console.WriteLine("\n" + "Turn " + playTurn);
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
            if(player != 2) // Because Player 2 is a CPU
            {
                Console.WriteLine("You are playing as player number => " + player);
            }
            Choice(); // Make your choice
        }
    }

    private static new void Choice()
    {
        if (player == 2)
        {
            CPU_CheckLeftOver();
            CPU_PlaceAMove();
            occupied_list.Clear(); // Clear the list instead of reinitializing
        }
        else if (player == 1)
        {
            // For Human Player
            Console.Write("(0 = Exit), Type a number between 1-9: ");
            choice = Console.ReadLine();
            Console.WriteLine("\n");

            if (choice == "0")
            {
                Console.WriteLine(choice + " Exiting...");
                Environment.Exit(0);
            }

            if (choice != "X" && choice != "O" && !string.IsNullOrWhiteSpace(choice))
            {
                bool validChoice = false;
                for (int i = 0; i < positions.Count; i++)
                {
                    if (positions[i] == choice)
                    {
                        positions[i] = "X";
                        playTurn++;
                        choice = "";
                        validChoice = true;
                        GameStart();
                        break;
                    }
                }
                if (!validChoice)
                {
                    ResetChoice();
                }
            }
            else
            {
                ResetChoice();
            }
        }
    }

    private static new void ResetChoice()
    {
        Console.WriteLine(choice + " is not a valid number, please choose a valid number.");
        choice = ""; // Reset choice to nothing
        Choice();
    }

    private static void CPU_CheckLeftOver()
    {
        occupied_list.Clear(); // Clear the list to avoid duplicates

        // Goes through the whole list one by one
        for (int i = 0; i < positions.Count; i++)
        {
            // Checks if the current position is not an X or an O
            // Saves the position number in a new list to be able to make choices
            if (positions[i] != "X" && positions[i] != "O")
            {
                occupied_list.Add(positions[i]);
            }
        }
    }

    private static void CPU_PlaceAMove()
    {
        Random random = new();
        string randomChoice;

        // Do the random again until it finds a string other than "0".
        do
        {
            int randomIndex = random.Next(occupied_list.Count); // Choose random string in the list
            randomChoice = occupied_list[randomIndex]; // Get the choice from the position
        } 
        while (randomChoice == "0");

        Console.WriteLine("CPU random choice: " + randomChoice); // Debug output

        for (int i = 0; i < positions.Count; i++)
        {
            if (positions[i] == randomChoice)
            {
                positions[i] = "O"; // Assume CPU uses "O"
                Console.WriteLine("CPU made a move on number => ( " + randomChoice + " )");
                playTurn++;
                choice = "";
                GameStart();
                break;
            }
        }
    }
}
