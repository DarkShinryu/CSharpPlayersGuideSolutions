BlockCoordinate startingBlock = new BlockCoordinate(0, 6);
Console.WriteLine(startingBlock);

BlockCoordinate secondBlock = startingBlock + new BlockOffset(1,- 3);
Console.WriteLine(secondBlock);

BlockCoordinate thirdBlock = startingBlock + Direction.West;
thirdBlock += Direction.North;
Console.WriteLine(thirdBlock);


public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate coordinate, BlockOffset offset)
    {
        return new BlockCoordinate(coordinate.Row + offset.RowOffset, coordinate.Column + offset.ColumnOffset);
    }

    public static BlockCoordinate operator +(BlockCoordinate coordinate, Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockCoordinate(Math.Clamp(coordinate.Row - 1, 0, 9), coordinate.Column), // Without clamping I guess they would just exit the city
            Direction.West  => new BlockCoordinate(coordinate.Row, Math.Clamp(coordinate.Column - 1, 0, 9)), // I'm also pretending the city is a boring 10x10 square
            Direction.South => new BlockCoordinate(coordinate.Row + 1, coordinate.Column),
            Direction.East  => new BlockCoordinate(coordinate.Row, coordinate.Column - 1),
            _               => coordinate
        };
    }
}

public record BlockOffset(int RowOffset, int ColumnOffset);

public enum Direction { North, East, South, West }