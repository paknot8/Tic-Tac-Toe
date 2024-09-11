class TicTacToeParent
{
    public static readonly List<string> positions = ["0","1", "2", "3", "4", "5", "6", "7", "8", "9"]; // The array of positions on the board.
    public static int player = 0; // Player 1 or player 2.
    public static string? choice; // choice of position.
    public static int playTurn = 0; // Turn starts at 0

    public static void GameStart()
    {
        Console.WriteLine("Turn " + playTurn);
        Board(); // Draw board
        
        // Do more in Child Classes
    }

    public static void Board()
    {
        Console.WriteLine(positions[1] + " | " + positions[2] + " | " + positions[3]);
        Console.WriteLine(positions[4] + " | " + positions[5] + " | " + positions[6]);
        Console.WriteLine(positions[7] + " | " + positions[8] + " | " + positions[9]);
    }

    // Check positions and if it's 3 beside each other then player won.
    public static int CheckWinner()
    {
        // --- Rows
        if (positions[1] == positions[2] && positions[2] == positions[3]) // Row 1
        {
            return 1;
        }
        else if (positions[4] == positions[5] && positions[5] == positions[6]) // Row 2
        {
            return 1;
        }
        else if (positions[7] == positions[8] && positions[8] == positions[9]) // Row 3
        {
            return 1;
        }

        // --- Columns
        else if (positions[1] == positions[4] && positions[4] == positions[7]) // Colum 1
        {
            return 1;
        }
        else if (positions[2] == positions[5] && positions[5] == positions[8]) // Colum 2
        {
            return 1;
        }
        else if (positions[3] == positions[6] && positions[6] == positions[9]) // Colum 3
        {
            return 1;
        }

        // --- Diagonals
        else if (positions[1] == positions[5] && positions[5] == positions[9]) // Diagonal 1
        {
            return 1;
        }
        else if (positions[3] == positions[5] && positions[5] == positions[7]) // Diagonal 2
        {
            return 1;
        }
        return 0;
    }

    // This is together to create the choices and the reset choice on wrong input.
    public static void Choice(){}
    public static void ResetChoice(){}
}