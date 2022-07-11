public class ItemAction : IAction
{
    private Character _character;

    public string Name => Item?.Name ?? "Item";
    public DamageType Type { get; } = DamageType.Normal;
    public Item? Item { get; set; }
    public Character? Target { get; private set; }
    public bool Success { get; private set; }

    public ItemAction(Character character) => _character = character;

    public void Use()
    {
        if (Target != null && Item?.Quantity > 0 && Success)
            Item.Use(Target);
    }

    public void SetTarget(Party heroes, Party villains)
    {
        if (_character is Hero || _character is VinFletcher || _character is MylaraAndSkorin)
        {
            if (_character.ControlMode == ControlMode.Automated)
            {
                foreach (Character character in heroes.Characters)
                {
                    if (character.Health.Percentage <= 0.2 && Item?.Type == ItemType.Elixir) Target = character;
                    else if (character.Health.Percentage <= 0.5 && Item?.Type == ItemType.Potion) Target = character;
                }

                return;
            }

            if (heroes.Characters.Count == 1)
            {
                Target = heroes.Characters[0];
                return;
            }

            HandleMultipleTargets(heroes, villains);
            return;
        }

        foreach (Character character in villains.Characters)
            Target = character;
    }

    public void SetSuccess() => Success = true;

    private void HandleMultipleTargets(Party heroes, Party villains)
    {
        if (heroes.Characters[0].ControlMode == ControlMode.Automated)
        {
            if (heroes.Characters.Count > 0)
                Target = villains.Characters[0];

            return;
        }

        int targetIndex;
        do
        {
            Console.Write($"Select a target (");
            for (int i = 0; i < heroes.Characters.Count; i++)
            {
                if (!heroes.Characters[i].IsDead)
                {
                    if (i + 1 == heroes.Characters.Count)
                    {
                        Console.Write($"{i + 1} - {heroes.Characters[i].Name}): ");
                        continue;
                    }

                    Console.Write($"{i + 1} - {heroes.Characters[i].Name} | ");
                }
            }

        } while (!int.TryParse(Console.ReadLine(), out targetIndex) || targetIndex <= 0 || targetIndex > heroes.Characters.Count);

        Target = heroes.Characters[targetIndex - 1];
    }
}