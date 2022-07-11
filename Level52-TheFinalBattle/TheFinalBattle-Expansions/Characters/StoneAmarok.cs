public class StoneAmarok : Character
{
    public StoneAmarok(string name, int startingExperience, ControlMode controlMode, ConsoleColor color) : base(name,startingExperience, controlMode, color)
    {
        ExperienceGiven = 800;
        GenerateLoot();

        AttackModifier = new AttackModifier(AttackModifierType.StoneArmor);
        Compiled = false;
        Action = new BiteAction();
    }

    protected override void AutomatedAction(Battle battle)
    {
        bool isVillainOnLowHealth = false;
        foreach (Character villain in battle.Villains.Characters)
            if (villain.Health.Percentage <= 0.2) { isVillainOnLowHealth = true; break; }

        if (!battle.Villains.Inventory.ItemsIsEmpty && isVillainOnLowHealth && _random.Next(1, 5) % 4 == 0)
        {
            ItemAction itemAction = new ItemAction(this);
            itemAction.Item = battle.Villains.Inventory.Items[ItemType.Potion];
            Action = itemAction;

            return;
        }

        Action = new BiteAction();
    }

    private void GenerateLoot()
    {
        Loot = new Inventory();

        if (Loot.Items[ItemType.Elixir].Quantity < 1)
            Loot.Items[ItemType.Elixir].Quantity = 1;
    }
}