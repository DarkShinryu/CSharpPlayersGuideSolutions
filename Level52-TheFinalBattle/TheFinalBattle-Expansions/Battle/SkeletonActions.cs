public class BoneCrunchAction : IAction
{
    private Random _random = new Random();
    private readonly int _maxDamage = 25;
    private Character _user;

    public string Name { get; protected set; }
    public DamageType Type { get; }
    public Character? Target { get; private set; }
    public bool Success { get; private set; }
    public int Damage { get; protected set; }

    public BoneCrunchAction(Character user)
    {
        _user = user;
        Name = "Bone Crunch";
        Type = DamageType.Normal;
    }

    public virtual void Use()
    {
        if (Target != null && Success)
        {
            Damage = _random.Next(15, _maxDamage + 1);

            if (Target.AttackModifier != null)
                Damage = Math.Clamp(Damage - Target.AttackModifier.Amount, 0, int.MaxValue);

            Target.Health.Current -= Damage;
        }
    }

    public void SetTarget(Party heroes, Party villains)
    {
        if (heroes.Characters.Contains(_user))
        {
            if (villains.Characters.Count == 1)
            {
                Target = villains.Characters[0];
                return;
            }

            HandleMultipleTargets(heroes, villains);
            return;
        }

        Target = heroes.Characters[_random.Next(heroes.Characters.Count)];
    }

    public void SetSuccess() => Success = true;

    private void HandleMultipleTargets(Party heroes, Party villains)
    {
        if (heroes.Characters[0].ControlMode == ControlMode.Automated)
        {
            if (villains != null && villains.Characters.Count > 0)
                Target = villains.Characters[0];

            return;
        }

        int targetIndex;
        do
        {
            Console.Write($"Select a target (");
            for (int i = 0; i < villains.Characters.Count; i++)
            {
                if (!villains.Characters[i].IsDead)
                {
                    if (i + 1 == villains.Characters.Count)  // Last enemy, needs different formatting
                    {
                        Console.Write($"{i + 1} - {villains.Characters[i]}): ");
                        continue;
                    }

                    Console.Write($"{i + 1} - {villains.Characters[i]} | ");
                }
            }

        } while (!int.TryParse(Console.ReadLine(), out targetIndex) || targetIndex <= 0 || targetIndex > villains.Characters.Count);

        Target = villains.Characters[targetIndex - 1];
    }
}

public class StabAction : BoneCrunchAction
{
    public StabAction(Character _user) : base(_user)
    {
        Name = "Stab";
        Damage = 30;
    }

    public override void Use()
    {
        if (Target != null && Success)
        {
            if (Target.AttackModifier != null)
                Damage = Math.Clamp(Damage - Target.AttackModifier.Amount, 0, int.MaxValue);

            Target.Health.Current -= Damage;
        }
    }
}