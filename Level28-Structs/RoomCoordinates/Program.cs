Coordinate coordinate1 = new Coordinate(5,4);
Coordinate coordinate2 = new Coordinate(6,4);
Coordinate coordinate3 = new Coordinate(7,3);

Console.WriteLine(Coordinate.AreAdjacent(coordinate1, coordinate2));
Console.WriteLine(Coordinate.AreAdjacent(coordinate1, coordinate3));
Console.WriteLine(Coordinate.AreAdjacent(coordinate2, coordinate3));

public struct Coordinate
{
    public int Row { get; }
    public int Column { get; }

    public Coordinate(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public static bool AreAdjacent(Coordinate first, Coordinate second)
    {
        if (Math.Abs(first.Row - second.Row) == 1 && Math.Abs(first.Column - second.Column) == 0)
            return true;
        if (Math.Abs(first.Column - second.Column) == 1 && Math.Abs(first.Row - second.Row) == 0)
            return true;

        return false;
    }
}