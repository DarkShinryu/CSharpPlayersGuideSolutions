public class ClawAction : IAction
{
    protected Random _random = new Random();

    public string Name { get; protected set; }
    public DamageType Type { get; protected set; }
    public Character? Target { get; private set; }
    public bool Success { get; private set; }
    public int Damage { get; protected set; }

    public ClawAction()
    {
        Name = "Claw";
        Type = DamageType.Normal;
        Damage = 50;
    }

    public virtual void Use()
    {
        if (Target != null && Success)
        {
            if (Target.AttackModifier != null)
                Damage = Math.Clamp(Damage - Target.AttackModifier.Amount, 0, int.MaxValue);

            Target.Health.Current -= Damage;
        }
    }

    public void SetTarget(Party heroes, Party villains) => Target = heroes.Characters[_random.Next(heroes.Characters.Count)];

    public void SetSuccess() => Success = true;
}

public class BitBreathAction : ClawAction
{
    public BitBreathAction()
    {
        Name = "Bit Breath";
        Type = DamageType.Decoding;
        Damage = 100;
    }

    public override void Use()
    {
        if (Target != null && Success)
        {
            if (Target.AttackModifier != null)
            {
                Target.AttackModifier.Action = this;
                Damage = Math.Clamp(Damage - Target.AttackModifier.Amount, 0, int.MaxValue);
            }

            Target.Health.Current -= Damage;
        }
    }
}