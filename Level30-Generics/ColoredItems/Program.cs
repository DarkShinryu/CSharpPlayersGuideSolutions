ColoredItems<Sword> coloredSword = new ColoredItems<Sword>(new Sword(), ConsoleColor.Blue);
ColoredItems<Bow> coloredBow = new ColoredItems<Bow>(new Bow(), ConsoleColor.Red);
ColoredItems<Axe> coloredAxe = new ColoredItems<Axe>(new Axe(), ConsoleColor.Green);

coloredSword.Display();
coloredBow.Display();
coloredAxe.Display();
public class ColoredItems<T>
{
    public T Item { get; }
    public ConsoleColor Color { get; }

    public ColoredItems(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        if (Item != null)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(Item.ToString());
            Console.ResetColor();
        }
    }
}

public class Sword { }
public class Bow { }
public class Axe { }