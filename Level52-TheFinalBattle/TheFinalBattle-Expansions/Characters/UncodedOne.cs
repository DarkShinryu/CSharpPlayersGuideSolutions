public class UncodedOne : Character
{
    private bool _uncodedJudgmentActionUsed = false;

    public UncodedOne(string name, int startingExperience, ControlMode controlMode, ConsoleColor color) : base(name, startingExperience, controlMode, color)
    {
        ExperienceGiven = 5000;
        Compiled = false;
        Action = new UnravelingAction();
    }

    protected override void AutomatedAction(Battle battle)
    {
        if (!_uncodedJudgmentActionUsed && Gear != null && Health.Percentage <= 0.15)
        {
            Action = new UncodedJudgmentAction();
            battle.Villains.Inventory.Gear[GearType.DecodedStaff].InPossession = false; // Uncoded's Judgment destroys the decoded staff after use
            UnEquipGear();
            _uncodedJudgmentActionUsed = true;

            return;
        }

        if (battle.Villains.Inventory.Items[ItemType.Elixir].Quantity > 0 && Health.Percentage <= 0.5)
        {
            ItemAction itemAction = new ItemAction(this);
            itemAction.Item = battle.Villains.Inventory.Items[ItemType.Elixir];
            Action = itemAction;

            return;
        }

        if (Gear != null)
        {
            Action = new DecodedApocalypseAction();
            return;
        }

        Action = Gear == null && battle.Villains.Inventory.Gear[GearType.DecodedStaff].InPossession && Health.Percentage <= 0.7 ?
            new EquipAction(this, battle.Villains) :
            new UnravelingAction();
    }
}