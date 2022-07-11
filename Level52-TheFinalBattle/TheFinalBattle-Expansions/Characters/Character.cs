// As part of the Making it Yours challenge I'm taking a difference approach with loot
// Each monster has a predefined set of inventory loot independent from the items/gear they use in battle

using System.Text;

public abstract class Character
{
    protected Random _random = new Random();
    private List<(int Number, IAction Action)> availableActions = new();

    public string Name { get; }
    public int Experience { get; set; }
    public int Level => Math.Clamp(value: Experience / 1000, min: 1, max: 99);
    public Health Health { get; }
    public ConsoleColor Color { get; }
    public ControlMode ControlMode { get; }
    public Status Status { get; set; }
    public int PoisonedTurns { get; set; }
    public Gear? Gear { get; private set; }
    public IAction Action { get; set; }
    public AttackModifier? AttackModifier { get; protected set; }
    public bool Compiled { get; set; }
    public int ExperienceGiven { get; protected set; }
    public Inventory? Loot { get; protected set; }
    public bool IsDead => Health.Current <= 0;

    public Character(string name, int startingExperience, ControlMode controlMode, ConsoleColor color)
    {
        Name = name;
        Experience = startingExperience;
        ExperienceGiven = 0;
        ControlMode = controlMode;
        Color = color;
        Health = new Health(this);
        Status = Status.Normal;
        Action = new NothingAction();
    }

    public void TakeTurn(Battle battle)
    {
        if (Status == Status.Poisoned && !IsDead)
            HandlePoisonedStatus();

        if (!IsDead)
        {
            SetAction(battle);
            Console.WriteLine();
            Action?.SetTarget(battle.Heroes, battle.Villains);
            Action?.SetSuccess();
            Action?.Use();
        }
    }

    private void SetAction(Battle battle)
    {
        if (ControlMode == ControlMode.Automated)
        {
            AutomatedAction(battle);
            return;
        }

        ManualAction(battle);
    }

    protected virtual void AutomatedAction(Battle battle) // Will need to be overridden for each villains
    {
        if (battle.Heroes.Inventory.Items[ItemType.Elixir].Quantity > 0 && Health.Percentage <= 0.2)
        {
            Action = new ItemAction(this) { Item = battle.Heroes.Inventory.Items[ItemType.Elixir] };
            return;
        }

        if (battle.Heroes.Inventory.Items[ItemType.Potion].Quantity > 0 && Health.Percentage <= 0.5)
        {
            Action = new ItemAction(this) { Item = battle.Heroes.Inventory.Items[ItemType.Potion] };
            return;
        }

        Action = Gear?.Type switch
        {
            GearType.Sword          => new SlashAction(GearType.Sword),
            GearType.Bow            => new QuickShotAction(),
            GearType.Cannon         => new CannonAction(battle.TurnCount),
            GearType.BitstoneSword  => new SlashAction(GearType.BitstoneSword),
            GearType.Dagger         => new StabAction(this),
            GearType.DecodedStaff   => new DecodedApocalypseAction(),
            _                       => new PunchAction()
        };
    }

    private void ManualAction(Battle battle)
    {
        IAction? action = null;

        do
        {
            Console.Write(ActionHandler(battle));
            string? actionAsStr = Console.ReadLine()?.ToLower();

            for (int i = 0; i < availableActions.Count; i++)
            {
                if (actionAsStr == availableActions[i].Number.ToString() || actionAsStr?.ToLower() == availableActions[i].Action.Name.ToLower())
                {
                    action = availableActions[i].Action;
                    break;
                }
            }
        } while (action == null);

        Action = action;

        if (Action is ItemAction itemAction)
            HandleItemAction(itemAction, battle.Heroes);
    }

    private string ActionHandler(Battle battle)  // I had to get a bit clever about the indexing of the availableActions to make this work
    {
        availableActions.Clear();

        availableActions.Add((availableActions.Count + 1, new NothingAction()));
        StringBuilder actionPrompt = new StringBuilder($"Enter an action ({availableActions[availableActions.Count - 1].Number} - {availableActions[availableActions.Count - 1].Action.Name} | ");

        availableActions.Add((availableActions.Count + 1, new PunchAction()));
        actionPrompt.Append($"{availableActions[availableActions.Count - 1].Number} - {availableActions[availableActions.Count - 1].Action.Name} | ");

        availableActions.Add(Gear?.Type switch
        {
            GearType.Sword          => (availableActions.Count + 1, new SlashAction(GearType.Sword)),
            GearType.Bow            => (availableActions.Count + 1, _random.Next() % 4 == 0 ? new PoisonShotAction() : new QuickShotAction()),
            GearType.Cannon         => (availableActions.Count + 1, new CannonAction(battle.TurnCount)),
            GearType.BitstoneSword  => (availableActions.Count + 1, new SlashAction(GearType.BitstoneSword)),
            GearType.Dagger         => (availableActions.Count + 1, new StabAction(this)),
            GearType.DecodedStaff   => (availableActions.Count + 1, new DecodedApocalypseAction()),
            _                       => (availableActions.Count + 1, new NothingAction())    // Dealing with this on the first line outside the switch expression
        });
        if (availableActions[availableActions.Count - 1].Action is NothingAction)
            availableActions.RemoveAt(availableActions.Count - 1);
        else
            actionPrompt.Append($"{availableActions[availableActions.Count - 1].Number} - {availableActions[availableActions.Count - 1].Action.Name} | ");

        if (this is Hero)
        {
            availableActions.Add((availableActions.Count + 1, new CompileAction()));
            actionPrompt.Append($"{availableActions[availableActions.Count - 1].Number} - {availableActions[availableActions.Count - 1].Action.Name} | ");
        }

        if (!battle.Heroes.Inventory.ItemsIsEmpty)
        {
            availableActions.Add((availableActions.Count + 1, new ItemAction(this)));
            actionPrompt.Append($"{availableActions[availableActions.Count - 1].Number} - {availableActions[availableActions.Count - 1].Action.Name} | ");
        }

        availableActions.Add((availableActions.Count + 1, Gear == null ? new EquipAction(this, battle.Heroes) : new UnEquipAction(this)));
        actionPrompt.Append($"{availableActions[availableActions.Count - 1].Number} - {availableActions[availableActions.Count - 1].Action.Name}): ");

        return actionPrompt.ToString();
    }

    private void HandleItemAction(ItemAction itemAction, Party heroes)
    {
        Item? item;
        do
        {
            Console.Write("Enter an item (1 - Potion | 2 - Elixir): ");
            item = Console.ReadLine()?.ToLower() switch
            {
                "1" or "potion" => heroes.Inventory.Items[ItemType.Potion],
                "2" or "elixir" => heroes.Inventory.Items[ItemType.Elixir],
                _ => null
            };

            if (item?.Quantity <= 0)
            {
                Console.WriteLine($"You don't have any {item.Name}s left.");
                item = null;
            }
        } while (item == null);

        itemAction.Item = item;
    }

    public void EquipGear(Inventory inventory, GearType gearType)
    {
        if (inventory.Gear[gearType].InPossession && !inventory.Gear[gearType].IsEquipped)
        {
            UnEquipGear();

            Gear = inventory.Gear[gearType];
            Gear.IsEquipped = true;
        }

    }

    public void UnEquipGear()
    {
        if (Gear != null)
        {
            Gear.IsEquipped = false;
            Gear = null;
        }
    }

    private void HandlePoisonedStatus()
    {
        if (PoisonedTurns == 3)
        {
            Status = Status.Normal;
            Console.WriteLine($"{Name} has naturally healed from poison after {PoisonedTurns} turns.\n");
            PoisonedTurns = 0;

            return;
        }

        int poisonDamage = (int)(Health.Max * ((double)_random.Next(5, 9) / 100));
        Health.Current -= poisonDamage;
        Display.PoisonResult(this, poisonDamage);
        PoisonedTurns++;
    }
}

public enum ControlMode { Manual, Automated }

public enum Status { Normal, Poisoned }