public class Game
{
    private HeroFactory _heroFactory = new HeroFactory();
    private SkeletonFactory _skeletonFactory = new SkeletonFactory();
    private BossFactory _bossFactory = new BossFactory();
    private Party _heroes;
    private Party _villains;
    private string _heroName;
    private int _totalBattles;
    private Battle? _battle;

    public Game()
    {
        _heroes = new Party("Heroes");
        _villains = new Party("Villains");
        _heroName = GetHeroName();
        _totalBattles = 3;
    }

    public void Run()
    {
        PopulateHeroesParty();

        for (int battleNumber = 1; battleNumber <= _totalBattles; battleNumber++)
        {
            if (_heroes.Defeated) break;

            PopulateVillainsParty(battleNumber);

            _battle = new Battle(_heroes, _villains);
            _battle.Start(battleNumber);
        }

        Display.GameResult(_heroes, _villains);
    }

    private void PopulateHeroesParty()
    {
        _heroes.Characters.Add(_heroFactory.CreateCharacter(_heroName));
    }

    private void PopulateVillainsParty(int battleNumber)
    {
        _villains.EmptyParty(); // There should be no need for this, but let's make sure it's actually empty

        switch (battleNumber)
        {
            case 1:
                _villains.Characters.Add(_skeletonFactory.CreateCharacter("Skeleton"));
                break;
            case 2:
                _villains.Characters.Add(_skeletonFactory.CreateCharacter("Skeleton"));
                _villains.Characters.Add(_skeletonFactory.CreateCharacter("Skeleton"));
                break;
            default:
                _villains.Characters.Add(_bossFactory.CreateCharacter("Uncoded One"));
                break;
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
}