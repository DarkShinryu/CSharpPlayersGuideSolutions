Arrow arrow = GetArrow();
Console.WriteLine($"This arrow costs {arrow.Cost:#.##} gold.");


Arrow GetArrow()
{
    Console.WriteLine("Which arrow do you want to buy?");
    Console.WriteLine("1 - Elite Arrow");
    Console.WriteLine("2 - Beginner Arrow");
    Console.WriteLine("3 - Marksman Arrow");
    Console.WriteLine("4 - Custom Arrow");

    return Console.ReadLine() switch
    {
        "1" => Arrow.CreateEliteArrow(),
        "2" => Arrow.CreateBeginnerArrow(),
        "3" => Arrow.CreateMarksmanArrow(),
        _   => new Arrow(GetArrowhead(), GetFletching(), GetLength())
    };
}

Arrowhead GetArrowhead()
{
    Arrowhead arrowhead = Arrowhead.Unknown;

    while (arrowhead == Arrowhead.Unknown)
    {
        Console.Write("Enter the arrowhead type (steel, wood, obsidian): ");

        arrowhead = Console.ReadLine().ToLower() switch
        {
            "steel" => Arrowhead.Steel,
            "wood" => Arrowhead.Wood,
            "obsidian" => Arrowhead.Obsidian,
            _ => Arrowhead.Unknown
        };
    }

    return arrowhead;
}

Fletching GetFletching()
{
    Fletching fletching = Fletching.Unknown;

    while (fletching == Fletching.Unknown)
    {
        Console.Write("Enter the fletching type (plastic, turkey, goose): ");

        fletching = Console.ReadLine().ToLower() switch
        {
            "plastic" => Fletching.Plastic,
            "turkey" => Fletching.TurkeyFeathers,
            "goose" => Fletching.GooseFeathers,
            _ => Fletching.Unknown
        };
    }

    return fletching;
}

float GetLength()
{
    float length = 0;

    while (length < 60 || length > 100)
    {
        Console.Write("Enter the length of the shaft (from 60 to 100): ");

        length = Convert.ToSingle(Console.ReadLine());
    }

    return length;
}

class Arrow
{
    public Arrowhead Arrowhead { get; }
    public Fletching Fletching { get; }
    public float Length { get; }

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Length = length;
    }

    public float Cost
    {
        get
        {
            float cost = 0f;

            cost += Arrowhead switch
            {
                Arrowhead.Steel => 10,
                Arrowhead.Wood => 3,
                Arrowhead.Obsidian => 5,
                _ => 0
            };
            cost += Fletching switch
            {
                Fletching.Plastic => 10,
                Fletching.TurkeyFeathers => 5,
                Fletching.GooseFeathers => 3,
                _ => 0
            };
            cost += Length * 0.05f;

            return cost;
        }
    }

    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Steel, Fletching.Plastic, 95f);
    public static Arrow CreateBeginnerArrow() => new Arrow(Arrowhead.Wood, Fletching.GooseFeathers, 75f);
    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Steel, Fletching.GooseFeathers, 65f);
}


enum Arrowhead { Unknown, Steel, Wood, Obsidian }
enum Fletching { Unknown, Plastic, TurkeyFeathers, GooseFeathers }