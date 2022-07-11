public class Battle
{
    private SkeletonFactory _skeletonFactory = new SkeletonFactory();
    private StoneAmarokFactory _stoneAmarokFactory = new StoneAmarokFactory();
    private BitDragonFactory _bitDragonFactory = new BitDragonFactory();
    private UncodedOneFactory _bossFactory = new UncodedOneFactory();
    private DateTime _startTime;

    public Party Heroes { get; }
    public Party Villains { get; }
    public int TurnCount { get; private set; }
    public int TotalBattleExperience { get; private set; }
    public Inventory Loot { get; }
    public TimeSpan Duration { get; private set; }

    public Battle(Party heroes)
    {
        Heroes = heroes;
        Villains = new Party(PartyType.Villains);
        Loot = new Inventory();
    }

    public void Start(int battleNumber)
    {
        PopulateVillainsParty(battleNumber);
        Villains.SetItemsQuantities();
        Villains.SetGearQuantities();
        EquipVillainsGear();
        GetTotalBattleExperience();
        GetBattleLoot();

        _startTime = DateTime.Now;
        while (!Heroes.IsDefeated && !Villains.IsDefeated)
        {
            Turn(Heroes, Villains);
            Turn(Villains, Heroes);
        }
        Duration = DateTime.Now - _startTime;

        DistributeExperience();
        DistributeLoot();

        Display.BattleResult(this);
    }

    private void Turn(Party party, Party opponentParty)
    {
        if (party.IsDefeated || opponentParty.IsDefeated)
            return;

        foreach (Character character in party.Characters)
        {
            if (!opponentParty.IsDefeated)
            {
                TurnCount++;

                Display.TurnInfo(this);

                Display.TurnIntro(character);

                if (party.Type == PartyType.Villains)
                    Display.Taunt(character);

                character.TakeTurn(this);
                Display.TurnExecution(character);

                party.RemoveDeadCharacters();
                opponentParty.RemoveDeadCharacters();

                EndTurn();
            }
        }
    }

    private void EndTurn()
    {
        Console.WriteLine();
        Console.Write("Press a key to end the turn...");
        Console.ReadKey(true);
        Console.Clear();
    }

    private void PopulateVillainsParty(int battleNumber)
    {
        switch (battleNumber)
        {
            case 1:
                Villains.Characters.Add(_skeletonFactory.CreateCharacter("Skeleton", 6000, ControlMode.Automated));
                break;

            case 2:
                Villains.Characters.Add(_skeletonFactory.CreateCharacter("Skeleton", 7000, ControlMode.Automated));
                Villains.Characters.Add(_skeletonFactory.CreateCharacter("Skeleton", 6000, ControlMode.Automated));
                break;

            case 3:
                Villains.Characters.Add(_stoneAmarokFactory.CreateCharacter("Stone Amarok", 8000, ControlMode.Automated));
                Villains.Characters.Add(_stoneAmarokFactory.CreateCharacter("Stone Amarok", 8000, ControlMode.Automated));
                break;

            case 4:
                Villains.Characters.Add(_bitDragonFactory.CreateCharacter("Bit Dragon", 10000, ControlMode.Automated));
                break;

            default:
                Villains.Characters.Add(_bossFactory.CreateCharacter("Uncoded One", 20000, ControlMode.Automated));
                break;
        }
    }

    private void EquipVillainsGear()
    {
        foreach (Character character in Villains.Characters)
        {
            switch (character)
            {
                case Skeleton:
                    character.EquipGear(Villains.Inventory, GearType.Dagger);
                    Villains.Inventory.Gear[GearType.Dagger].IsEquipped = false;

                    break;
                default:
                    break;
            }
        }
    }

    private void GetTotalBattleExperience()
    {
        foreach (Character villain in Villains.Characters)
            TotalBattleExperience += villain.ExperienceGiven;
    }

    private void DistributeExperience()
    {
        foreach (Character character in Heroes.Characters)
            character.Experience += TotalBattleExperience;
    }

    private void GetBattleLoot()
    {
        foreach (Character villain in Villains.Characters)
        {
            if (villain.Loot != null)
            {
                foreach (Item item in villain.Loot.Items.Values)
                    Loot.Items[item.Type].Quantity += item.Quantity;

                foreach (Gear gear in villain.Loot.Gear.Values)
                {
                    if (gear.InPossession && !Heroes.Inventory.Gear[gear.Type].InPossession)
                        Loot.Gear[gear.Type].InPossession = true;
                }
            }
        }

        if (Loot.Items[ItemType.Elixir].Quantity > 1)
            Loot.Items[ItemType.Elixir].Quantity = 1;   // I don't want more than 1 elixir per battle
    }

    private void DistributeLoot()
    {
        if (!Loot.ItemsIsEmpty)
        {
            foreach (Item item in Loot.Items.Values)
                Heroes.Inventory.Items[item.Type].Quantity += item.Quantity;
        }
        if (!Loot.GearIsEmpty)
        {
            foreach (Gear gear in Loot.Gear.Values)
            {
                if (gear.InPossession)
                    Heroes.Inventory.Gear[gear.Type].InPossession = true;
            }
        }
    }
}