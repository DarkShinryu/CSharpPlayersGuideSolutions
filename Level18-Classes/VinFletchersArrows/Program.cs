Arrow arrow = new Arrow(GetArrowhead(), GetFletching(), GetLength());
Console.WriteLine($"This arrow costs {arrow.GetCost():#.##} gold.");


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
    public Arrowhead arrowhead;
    public Fletching fletching;
    public float length;

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        this.arrowhead = arrowhead;
        this.fletching = fletching;
        this.length = length;
    }

    public float GetCost()
    {
        float cost = 0f;

        cost += arrowhead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5,
            _ => 0
        };

        cost += fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3,
            _ => 0
        };

        cost += length * 0.05f;

        return cost;
    }
}


enum Arrowhead { Unknown, Steel, Wood, Obsidian }
enum Fletching { Unknown, Plastic, TurkeyFeathers, GooseFeathers }