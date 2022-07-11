public class Game
{
    private HeroFactory _heroFactory = new HeroFactory();
    private VinFletcherFactory _vinFactory = new VinFletcherFactory();
    private MylaraAndSkorinFactory _mylaraAndSkorinFactory = new MylaraAndSkorinFactory();
    private string _heroName;
    private Character _hero;
    private Character _vin;
    private Character _mylaraAndSkorin;
    private int _totalBattles;
    private Battle? _battle;

    public Party Heroes { get; }

    public Game()
    {
        _heroName = GetHeroName();
        _hero = _heroFactory.CreateCharacter(_heroName, 8000, GetControlMode());
        _vin = _vinFactory.CreateCharacter("Vin Fletcher", 7300, _hero.ControlMode);
        _mylaraAndSkorin = _mylaraAndSkorinFactory.CreateCharacter("Mylara and Skorin", 6500, _hero.ControlMode);
        Heroes = new Party(PartyType.Heroes);
        _totalBattles = 5;
    }

    public void Run()
    {
        PopulateHeroesParty();
        Heroes.SetItemsQuantities();
        Heroes.SetGearQuantities();
        EquipHeroesGear();

        for (int battleNumber = 1; battleNumber <= _totalBattles; battleNumber++)
        {
            if (battleNumber == _totalBattles)
                FinalBattlePreparations();

            if (Heroes.IsDefeated)
                break;

            _battle = new Battle(Heroes);
            _battle.Start(battleNumber);
        }

        if (_battle != null)
            Display.GameResult(Heroes, _battle.Villains);
    }

    private void PopulateHeroesParty()
    {
        Heroes.Characters.Add(_hero);
        Heroes.Characters.Add(_vin);
        Heroes.Characters.Add(_mylaraAndSkorin);
    }

    private void EquipHeroesGear()
    {
        foreach (Character character in Heroes.Characters)
        {
            switch (character)
            {
                case Hero:
                    character.EquipGear(Heroes.Inventory, GearType.Sword);
                    break;
                case VinFletcher:
                    character.EquipGear(Heroes.Inventory, GearType.Bow);
                    break;
                case MylaraAndSkorin:
                    character.EquipGear(Heroes.Inventory, GearType.Cannon);
                    break;
                default:
                    break;
            }
        }
    }

    private string GetHeroName()
    {
        string? name;
        do
        {
            Console.Write("Enter the true programmer's name: ");
            name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(name));

        return name;
    }

    private ControlMode GetControlMode()
    {
        ControlMode? controlMode;

        do
        {
            Console.Write("Enter the control mode for your characters (1 - Manual | 2 - Auto): ");
            controlMode = Console.ReadLine()?.ToLower() switch
            {
                "1" or "manual" => ControlMode.Manual,
                "2" or "auto" => ControlMode.Automated,
                _ => null
            };
        } while (controlMode == null);

        Console.Clear();

        return (ControlMode)controlMode;    // This cast is safe, I'm preventing null in the loop above
    }

    private void FinalBattlePreparations()
    {
        Console.WriteLine("The Bit Dragon thanks you for freeing him from the Uncoded One's control.");
        Thread.Sleep(5000);
        Console.WriteLine("\"The Uncoded One awaits you behind this door, but it is sealed.\"");
        Thread.Sleep(5000);
        Console.WriteLine("\"I will remove it with what little of my power remains.\"");
        Thread.Sleep(5000);
        Console.WriteLine("You watch the Dragon remove the seal as he disappears into nothingness.");
        Thread.Sleep(5000);
        Console.WriteLine("\"Enjoy this last gift...\" A sword magically appears in your hands, it's the legendary Bitstone Sword!\n");
        Thread.Sleep(5000);
        Console.WriteLine("In preparation for the final battle you equip your shiny new Bitsword and rest for a few hours.\n");
        Thread.Sleep(5000);

        Heroes.HealParty();
        Heroes.Inventory.Gear[GearType.BitstoneSword].InPossession = true;
        _hero.EquipGear(Heroes.Inventory, GearType.BitstoneSword);

        Console.Write("Press a key to continue...");
        Console.ReadKey(true);

        Console.Clear();
    }
}