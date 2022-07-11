public static class Display
{
    public static void Board(Game game)
    {
        // Bit of a messy code ahead 'cause console sucks, pretend it's magic and the following is the end result :P
        /*
             +----+----+----+----+
             |    | 01 | 02 | 03 |
             |----+----+----+----|
             | 04 | 05 | 06 | 07 |
             |----+----+----+----|
             | 08 | 09 | 10 | 11 |
             |----+----+----+----|
             | 12 | 13 | 14 | 15 |
             +----+----+----+----+
        */

        Console.WriteLine($"{game.Board.Size - 1}-Puzzle!");
        Console.WriteLine("\n\t+----+----+----+----+");

        for (int row = 0; row < game.Board.Tiles.GetLength(0); row++)
        {
            if (row > 0) Console.WriteLine("\t|----+----+----+----|");

            for (int col = 0; col < game.Board.Tiles.GetLength(1); col++)
            {
                if (col == 0) Console.Write('\t');

                if (game.Board.Tiles[row, col] == 0)
                    Console.Write($"|    ");
                else
                    Console.Write($"| {game.Board.Tiles[row, col]:00} ");
            }

            Console.Write("|");
            Console.WriteLine();
        }

        Console.WriteLine("\t+----+----+----+----+\n");
    }

    public static void End(Game game) => Console.WriteLine($"You solved the puzzle in {game.Player.MovesCount} moves.");
}