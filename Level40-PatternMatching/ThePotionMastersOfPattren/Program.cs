PotionGame potionGame = new PotionGame();
potionGame.Run();

public class PotionGame
{
    private Potion _potion;
    private Ingredient _ingredient;
    private bool _isGameOver;

    public void Run()
    {
        while (!_isGameOver)
        {
            Console.Clear();

            Console.WriteLine($"Current potion: {_potion}.\n\nAvailable ingredients:");
            foreach (string ingredient in Enum.GetNames(typeof(Ingredient)))
                Console.WriteLine($"- " + ingredient);

            SetIngredient();
            UpdatePotion();

            Console.Clear();

            PotionCheck();
            EndGameCheck();
        }
    }

    private void SetIngredient()
    {
        Ingredient ingredient;
        do
        {
            Console.Write("Enter the ingredient to use: ");
        } while (!Enum.TryParse(Console.ReadLine(), true, out ingredient));

        _ingredient = ingredient;
    }

    private void UpdatePotion()
    {
        Potion updatedPotion = (_potion, _ingredient) switch
        {
            (Potion.Water,              Ingredient.Stardust)     => Potion.Elixir,
            (Potion.Elixir,             Ingredient.SnakeVenom)   => Potion.PoisonPotion,
            (Potion.Elixir,             Ingredient.DragonBreath) => Potion.FlyingPotion,
            (Potion.Elixir,             Ingredient.ShadowGlass)  => Potion.InvisibilityPotion,
            (Potion.Elixir,             Ingredient.EyeshineGem)  => Potion.NightSightPotion,
            (Potion.NightSightPotion,   Ingredient.ShadowGlass)  => Potion.CloudyBrew,
            (Potion.InvisibilityPotion, Ingredient.EyeshineGem)  => Potion.CloudyBrew,
            (Potion.CloudyBrew,         Ingredient.Stardust)     => Potion.WraithPotion,
            _                                                    => Potion.RuinedPotion
        };

        _potion = updatedPotion;
    }

    private void PotionCheck()
    {
        Console.WriteLine($"Result: {_potion}.");

        if (_potion == Potion.RuinedPotion)
        {
            Console.WriteLine("You'll have to start over.");
            _potion = Potion.Water;
        }
    }

    private void EndGameCheck()
    {
        Console.Write("Do you want to continue? ");
        _isGameOver = Console.ReadLine()?.ToLower() == "no" ? true : false;
    }
}

public enum Potion
{
    Water,
    Elixir,
    PoisonPotion,
    FlyingPotion,
    InvisibilityPotion,
    NightSightPotion,
    CloudyBrew,
    WraithPotion,
    RuinedPotion
}
public enum Ingredient
{
    Stardust,
    SnakeVenom,
    DragonBreath,
    ShadowGlass,
    EyeshineGem
}