public class Cavern
{
    public Coordinate EntrancePos { get; }
    public Coordinate FountainPos { get; }
    public (int Min, int Max) OuterWallsRow { get; } // Mathematically I could use a coordinate but the these are not coords so I'd rather use a tuple to get better names
    public (int Min, int Max) OuterWallsCol { get; } // By separating row and col we can have not squared caverns without altering the code

    public Cavern(int rowCount, int colCount)
    {
        EntrancePos = new Coordinate(0, 0);
        FountainPos = new Coordinate(0, 2);
        OuterWallsRow = (0, rowCount);
        OuterWallsCol = (0, colCount);
    }
}