public interface IAction
{
    string Name { get; }
    int Damage { get; }
    Character? Target { get; set; }
}

public class NothingAction : IAction
{
    public string Name { get; }
    public int Damage => 0;
    public Character? Target { get; set; }

    public NothingAction() => Name = "Nothing";
}

public class PunchAction : IAction
{
    public string Name { get; }
    public int Damage => 1;
    public Character? Target { get; set; }

    public PunchAction() => Name = "Punch";
}

public class BoneCrunchAction : IAction
{
    private Random _random = new Random();
    private int _maxDamage = 1;
    public string Name { get; }
    public Character? Target { get; set; }
    public int Damage { get; private set; }

    public BoneCrunchAction() => Name = "Bone Crunch";

    public void SetDamage() => Damage = _random.Next(_maxDamage + 1);
}

public class UnravelingAction : IAction
{
    private Random _random = new Random();
    private int _maxDamage = 2;

    public string Name { get; }
    public Character? Target { get; set; }
    public int Damage { get; private set; }

    public UnravelingAction() => Name = "Unraveling";

    public void SetDamage() => Damage = _random.Next(_maxDamage + 1);
}