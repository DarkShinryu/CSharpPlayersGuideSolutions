public class Skeleton : Character
{
    public Skeleton(string name, int startingExperience, ControlMode controlMode, ConsoleColor color) : base(name, startingExperience, controlMode, color)
    {
        ExperienceGiven = 500;
        GenerateLoot();

        Compiled = false;
        Action = new BoneCrunchAction(this);
    }

    protected override void AutomatedAction(Battle battle)
    {
        bool isVillainOnLowHealth = false;
        foreach (Character villain in battle.Villains.Characters)
            if (villain.Health.Percentage <= 0.3) { isVillainOnLowHealth = true; break; }

        if (!battle.Villains.Inventory.ItemsIsEmpty && isVillainOnLowHealth && _random.Next(1, 5) % 3 == 0)
        {
            ItemAction itemAction = new ItemAction(this);
            itemAction.Item = battle.Villains.Inventory.Items[ItemType.Potion];
            Action = itemAction;

            return;
        }

        if (Gear != null)
        {
            Action = _random.Next(1, 11) % 4 == 0 ? new BoneCrunchAction(this) : new StabAction(this);
            return;
        }

        Action = new BoneCrunchAction(this);
    }

    private void GenerateLoot()
    {
        Loot = new Inventory();

        int rng = _random.Next();

        if (rng % 3 == 0)
            Loot.Items[ItemType.Potion].Quantity = 1;
        else if (rng % 5 == 0)
            Loot.Items[ItemType.Potion].Quantity = 2;

        rng = _random.Next();
        if (rng % 5 != 0)
            Loot.Gear[GearType.Dagger].InPossession = true;
    }
}