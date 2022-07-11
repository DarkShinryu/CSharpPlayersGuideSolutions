public class Player
{
    private Board board;
    public int MovesCount { get; set; }

    public Player(Board board)
    {
        this.board = board;
        MovesCount = 0;
    }

    public void MoveTile(int tileValue)
    {
        bool areAdjacent = false;

        (int Row, int Col) emptyPosition = board.GetTilePosition(0);
        (int Row, int Col) tilePosition = board.GetTilePosition(tileValue);

        // A tile can only be moved if it's adjacent to the empty space
        if (Math.Abs(emptyPosition.Row - tilePosition.Row) == 1)
            areAdjacent = emptyPosition.Col == tilePosition.Col;
        else if (emptyPosition.Row == tilePosition.Row)
            areAdjacent = Math.Abs(emptyPosition.Col - tilePosition.Col) == 1;

        if (areAdjacent)
        {
            board.Tiles[emptyPosition.Row, emptyPosition.Col] = tileValue;
            board.Tiles[tilePosition.Row, tilePosition.Col] = 0;
        }

        Console.Clear();
    }
}