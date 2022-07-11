public static class Display
{
    public static void MainScreen(Player player, Sign[,] board)
    {
        Console.Clear();
        Console.WriteLine($"{player.Name} ({player.Sign}), it's your turn");
        DisplayBoard(board);
    }

    public static void EndScreen(Sign[,] board, Player[] players, Game game)
    {
        Console.Clear();
        DisplayBoard(board);

        if (game.IsDraw)
        {
            Console.WriteLine("This game ended in a draw.");
            return;
        }

        foreach (Player player in players)
        {
            if (player.IsWinner)
                Console.WriteLine($"{player.Name} is the winner!");
        }
    }

    private static void DisplayBoard(Sign[,] board)
    {
        Console.WriteLine();

        for (int row = 0; row < board.GetLength(0); row++)
        {
            for (int col = 0; col < board.GetLength(1); col++)
            {
                char signAsChar = board[row, col] == Sign.Empty ? ' ' : Convert.ToChar(board[row, col].ToString());

                if (col != 1)
                    Console.Write($" {signAsChar} ");
                else
                    Console.Write($"| {signAsChar} |");
            }

            Console.WriteLine();
            if (row < 2)
                Console.WriteLine("---+---+---");
        }

        Console.WriteLine();
    }
}