public class Game
{
    private bool IsGameOver => Player.IsAtEntranceRoom && Player.HasEnabledFountain;    // Private properties have their uses, a calculated value in this case
    public Player Player { get; }

    public Game(Cavern cavern) => Player = new Player(cavern);

    public void Run()
    {
        Display.Intro();
        GetPlayerName();
        Console.Clear();

        while (!IsGameOver)
        {
            Display.GameStatus(Player);
            Display.PlayerPrompt($"{Player.Name}, what do you want to do? ");
            Player.Move(Console.ReadLine() ?? "Unknown");
        }

        Display.GameStatus(Player);
        Display.Win();
    }

    private void GetPlayerName()
    {
        do
        {
            Display.PlayerPrompt("Enter your name: ");
            Player.SetName();
        } while (string.IsNullOrWhiteSpace(Player.Name));   // Nice built in method!
    }
}