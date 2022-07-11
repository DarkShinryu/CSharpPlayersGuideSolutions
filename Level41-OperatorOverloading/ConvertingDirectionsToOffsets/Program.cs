BlockCoordinate block = new BlockCoordinate(2, 9);
Console.WriteLine($"Row: {block.Row} | Column: {block.Column}");

BlockCoordinate offsettedBlock = block + Direction.South;
Console.WriteLine($"Row: {offsettedBlock.Row} | Column: {offsettedBlock.Column}");

public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate coordinate, BlockOffset offset)
        => new BlockCoordinate(coordinate.Row + offset.RowOffset, coordinate.Column + offset.ColumnOffset);
}
public record BlockOffset(int RowOffset, int ColumnOffset)
{
    public static implicit operator BlockOffset(Direction direction)
    {
        return direction switch
        {
            Direction.North => new BlockOffset(-1,  0),
            Direction.South => new BlockOffset( 1,  0),
            Direction.West  => new BlockOffset( 0, -1),
            Direction.East  => new BlockOffset( 0,  1),
            _               => new BlockOffset( 0,  0),
        };
    }
}
public enum Direction { North, East, South, West }


// I made the custom conversion implicit since it doesn't cause any loss of data.