public class BiteAction : IAction
{
    private Random _random = new Random();

    public string Name { get; }
    public DamageType Type { get; }
    public Character? Target { get; private set; }
    public bool Success { get; private set; }
    public int Damage { get; private set; } = 25;

    public BiteAction()
    {
        Name = "Bite";
        Type = DamageType.Normal;
    }

    public void Use()
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