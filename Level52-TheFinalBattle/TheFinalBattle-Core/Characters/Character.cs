public abstract class Character
{
    public string Name { get; }
    public ConsoleColor Color { get; }
    public Health Health { get; }
    public Party? TargetParty { get; set; }
    public IAction Action { get; protected set; }
    public bool IsDead => Health.Current <= 0;

    public Character(string name, ConsoleColor color, int maxHealth)
    {
        Name = name;
        Color = color;
        Health = new Health(maxHealth, maxHealth);
        Action = new NothingAction();   // Treating nothing as the default action
    }

    public virtual void TakeTurn()
    {
        Action.Target = null;
        if (Action is BoneCrunchAction boneCrunchAction) boneCrunchAction.SetDamage();
        if (Action is UnravelingAction unravelingAction) unravelingAction.SetDamage();
        SetActionTarget();

        if (Action.Target != null)
            Action.Target.Health.Current -= Action.Damage;
    }

    protected virtual void SetActionTarget()
    {
        if (TargetParty != null && TargetParty.Characters.Count == 1) // If there's only one enemy alive the program selects the target automatically
            Action.Target = TargetParty.Characters[0];
    }
}