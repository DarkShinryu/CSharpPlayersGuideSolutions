CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (tree.FruitCount < 6)
    tree.MaybeGrow();

Console.WriteLine($"We've harvested {tree.FruitCount} fruits, that's enough for a month.");



public class CharberryTree
{
    private Random _random = new Random();

    public event Action? Ripened;

    public bool Checking { get; set; } = true;
    public bool Ripe { get; set; }
    public int FruitCount { get; set; }

    public void MaybeGrow()
    {
        if (Checking)
        {
            Console.Write("Checking...");
            Checking = false;
        }

        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}

public class Notifier
{
    public Notifier(CharberryTree tree) => tree.Ripened += OnTreeRipened;

    private void OnTreeRipened() => Console.WriteLine("\nA charberry fruit has ripened!");
}

public class Harvester
{
    private CharberryTree _tree;

    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        _tree.Ripened += OnTreeRipened;
    }

    private void OnTreeRipened()
    {
        _tree.Ripe = false;
        _tree.FruitCount++;
        _tree.Checking = true;
        Console.WriteLine($"The charberry fruit has been harvested, we have {_tree.FruitCount} fruit/s in total!\n");
    }
}