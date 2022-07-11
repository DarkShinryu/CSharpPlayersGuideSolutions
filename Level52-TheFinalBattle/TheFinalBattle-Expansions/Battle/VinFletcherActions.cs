public class QuickShotAction : PunchAction
{
    private Random _random = new Random();

    public QuickShotAction()
    {
        Name = "Quick Shot";
        Damage = 50;
    }

    public override void SetSuccess() => Success = _random.NextDouble() >= 0.2;
}

public class PoisonShotAction : PunchAction
{
    private Random _random = new Random();

    public PoisonShotAction()
    {
        Name = "Poison Shot";
        Damage = 20;
    }

    public override void Use()
    {
        if (Target != null && Success)
        {

            if (Target.AttackModifier != null)
                Damage = Math.Clamp(Damage - Target.AttackModifier.Amount, 0, int.MaxValue);

            Target.Health.Current -= Damage;
            Target.Status = Status.Poisoned;
            Target.PoisonedTurns = 3;
        }
    }

    public override void SetSuccess() => Success = _random.NextDouble() >= 0.2;
}