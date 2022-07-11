public class Game
{
    private readonly Player _player;
    private readonly Cavern _cavern;
    private readonly Music _music;
    private DateTime _startTime;
    private DateTime _endTime;
    private TimeSpan _duration;

    private bool IsGameOver => (_player.IsAtEntranceRoom && _player.HasEnabledFountain) || _player.IsDead;

    public Game(Cavern cavern, int arrowCount)
    {
        _cavern = cavern;
        _player = new Player(cavern, arrowCount);
        _music = new Music();
    }

    public void Run()
    {
        Console.Clear();
        _startTime = DateTime.Now;

        while (!IsGameOver)
            RunTurn();

        RunEndGame();
    }

    private void RunTurn()
    {
        Display.GameStatus(_player, _cavern);
        Display.PlayerPrompt($"What do you want to do? ");
        _player.Command(Console.ReadLine() ?? "Unknown");
        MaelstromCheck();
    }

    private void RunEndGame()
    {
        Display.GameStatus(_player, _cavern);

        _endTime = DateTime.Now;
        _duration = _endTime - _startTime;

        if (_player.IsDead)
        {
            Display.Result("You lose!");
            Display.Result($"Total play time: {_duration.Hours:00}:{_duration.Minutes:00}:{_duration.Seconds:00}.");
            _music.Loss();
        }
        else
        {
            Display.Result("You win!");
            Display.Result($"Total play time: {_duration.Hours:00}:{_duration.Minutes:00}:{_duration.Seconds:00}.");
            _music.Victory();
        }

    }

    private void MaelstromCheck()
    {
        if (_player.IsAtMaelstromRoom)
        {
            _cavern.UpdateMealstromPosition(_player.CurrentRoom);   // This has to be first, we need the player position BEFORE the player is teleported
            _player.Teleport();
        }
    }
}