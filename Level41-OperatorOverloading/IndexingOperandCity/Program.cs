BlockCoordinate block = new BlockCoordinate(7, 3);
Console.WriteLine($"Row: {block[0]} | Column: {block[1]}");


public record BlockCoordinate(int Row, int Column)
{
    public int this[int index] => index switch { 0 => Row, _ => Column};    // Discard instead of 1 just to shut up the compiler
}
public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction { North, East, South, West }


// Using an indexer in this type of class doesn't make much sense, the code is less clear than using directly Row and Column and doesn't offer any advantage