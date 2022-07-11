public class UnravelingAction : IAction
{
    private Random _random = new Random();
    private readonly int _maxDamage = 100;

    public string Name { get; protected set; }
    public DamageType Type { get; protected set; }
    public Character? Target { get; private set; }
    public bool Success { get; private set; }
    public int Damage { get; protected set; }

    public UnravelingAction()
    {
        Name = "Unraveling";
        Type = DamageType.Decoding;
    }

    public virtual void Use()
    {
        if (Target != null && Success)
        {
            Damage = _random.Next(89, _maxDamage + 1);

            if (Target.AttackModifier != null)
            {
                Target.AttackModifier.Action = this;
                Damage = Math.Clamp(Damage - Target.AttackModifier.Amount, 0, int.MaxValue);
            }

            Target.Health.Current -= Damage;
        }
    }

    public void SetTarget(Party heroes, Party villains) => Target = heroes.Characters[_random.Next(heroes.Characters.Count)];

    public void SetSuccess() => Success = true;
}

public class DecodedApocalypseAction : UnravelingAction
{
    public DecodedApocalypseAction()
    {
        Name = "Decoded Apocalypse";
        Damage = 200;
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

public class UncodedJudgmentAction : UnravelingAction
{
    public UncodedJudgmentAction()
    {
        Name = "Uncoded's Judgment";
        Type = DamageType.Normal;
    }

    public override void Use()
    {
        if (Target != null && Success)
        {
            Damage = Target.Health.Current - 1;

            if (Target.AttackModifier != null)
            {
                Target.AttackModifier.Action = this;
                Damage = Math.Clamp(Damage - Target.AttackModifier.Amount, 0, int.MaxValue);
            }

            Target.Health.Current -= Damage;
        }
    }
}