public class PunchAction : IAction
{
    public string Name { get; protected set; }
    public DamageType Type { get; }
    public Character? Target { get; private set; }
    public bool Success { get; protected set; }
    public int Damage { get; protected set; }

    public PunchAction()
    {
        Name = "Punch";
        Type = DamageType.Normal;
        Damage = 20;
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

    public void SetTarget(Party heroes, Party villains)
    {
        if (villains.Characters.Count == 1)
        {
            Target = villains.Characters[0];
            return;
        }

        HandleMultipleTargets(heroes, villains);
    }

    public virtual void SetSuccess() => Success = true;

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

public class SlashAction : PunchAction
{
    public SlashAction(GearType gearType)
    {
        Name = "Slash";
        Damage = 40;

        if (gearType == GearType.BitstoneSword)
            Damage = 100;
    }
}

public class CompileAction : IAction
{

    public string Name { get; } = "Compile";
    public DamageType Type { get; } = DamageType.Normal;
    public Character? Target { get; private set; }
    public bool Success { get; private set; }

    public virtual void Use()
    {
        if (Target != null && Success)
            Target.Compiled = true;
    }

    public void SetTarget(Party heroes, Party villains)
    {
        if (villains.Characters.Count == 1)
        {
            Target = villains.Characters[0];
            return;
        }

        HandleMultipleTargets(heroes, villains);
    }

    public virtual void SetSuccess() => Success = true;

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