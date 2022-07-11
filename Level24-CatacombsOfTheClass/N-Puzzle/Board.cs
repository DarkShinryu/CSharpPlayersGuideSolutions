// Note: I'm using the value zero to represent an empty tile

public class Board
{
    private int tilesAmount;
    private int[] tilesValues;

    public int Size { get; }
    public int[,] Tiles { get; }

    public Board(int tilesAmount)
    {
        this.tilesAmount = tilesAmount;
        Size = tilesAmount + 1;  // N in N-Puzzle is TilesAmount + 1 empty space
        tilesValues = GenerateTilesValues(true);
        Tiles = new int[(int)Math.Sqrt(Size), (int)Math.Sqrt(Size)];
    }

    public void PopulateBoard()
    {
        int tilesValuesIndex = 0;   // We need this to keep track of the values[] index while we go through the board
        for (int row = 0; row < Tiles.GetLength(0); row++)
        {
            for (int col = 0; col < Tiles.GetLength(1); col++)
                Tiles[row, col] = tilesValues[tilesValuesIndex++];
        }
    }

    public (int, int) GetTilePosition(int tileValue)
    {
        (int Row, int Col) tilePosition = (0, 0);

        for (int row = 0; row < Tiles.GetLength(0); row++)
        {
            for (int col = 0; col < Tiles.GetLength(1); col++)
            {
                if (Tiles[row, col] == tileValue)
                {
                    tilePosition.Row = row;
                    tilePosition.Col = col;
                }
            }
        }

        return tilePosition;
    }

    public int GetTileValue()
    {
        int tileValue;
        do
        {
            Console.Write("Enter the value of the tile you want to move: ");
            tileValue = Convert.ToInt32(Console.ReadLine());
        } while (tileValue < 1 || tileValue > tilesAmount);

        return tileValue;
    }

    public bool IsOrdered()
    {
        int[] orderedValues = GenerateTilesValues(false);
        int tilesValuesIndex = 0;

        for (int row = 0; row < Tiles.GetLength(0); row++)
        {
            for (int col = 0; col < Tiles.GetLength(1); col++)
                if (Tiles[row,col] != orderedValues[tilesValuesIndex++]) return false;
        }

        return true;
    }
    private int[] GenerateTilesValues(bool isShuffled)
    {
        int[] tilesValues = new int[Size];
        for (int i = 1; i <= Size; i++)
        {
            if (i == Size) tilesValues[i - 1] = 0;
            else           tilesValues[i - 1] = i;
        }

        if (isShuffled)
        {
            Random random = new Random();
            tilesValues = tilesValues.OrderBy(x => random.Next()).ToArray();    // This shuffles the element of an array
        }

        return tilesValues;
    }
}