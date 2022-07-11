Point firstPoint = new Point(2, 3);
Point secondPoint = new Point(-4, 0);

Console.WriteLine($"{firstPoint.X}, {firstPoint.Y}");
Console.WriteLine($"{secondPoint.X}, {secondPoint.Y}");


public class Point
{
    public int X { get; }
    public int Y { get; }


    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Point()
    {
        X = 0;
        Y = 0;
    }
}


// Answer this question: Are your X and Y properties immutable? Why did you choose what you did?
// Yes they are. The challenge does not require the user to change the values of X and Y after construction, making them immutable make the object easier to work with.