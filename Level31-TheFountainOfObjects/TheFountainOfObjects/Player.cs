public class Player
{
    private readonly Cavern _cavern;
    private IPlayerCommand? _command;

    public string Name { get; private set; }
    public Coordinate CurrentPos { get; set; }
    public bool HasEnabledFountain { get; set; }
    public bool IsAtEntranceRoom => CurrentPos == _cavern.EntrancePos;
    public bool IsAtFountainRoom => CurrentPos == _cavern.FountainPos;

    public Player(Cavern cavern)
    {
        _cavern = cavern;
        Name = string.Empty;
        CurrentPos = _cavern.EntrancePos;   // The player starts at the entrance
        HasEnabledFountain = false;
    }

    public void SetName() => Name = Console.ReadLine() ?? string.Empty;

    public void Move(string playerCommand)
    {
        switch (playerCommand.ToLower())
        {
            case "n":
            case "move north":
                _command = new NorthCommand();
                break;

            case "s":
            case "move south":
                _command = new SouthCommand();
                break;

            case "w":
            case "move west":
                _command = new WestCommand();
                break;

            case "e":
            case "move east":
                _command = new EastCommand();
                break;

            case "f":
            case "enable fountain":
                _command = new FountainCommand();
                break;

            default:
                _command = null;
                break;
        }

        if (_command != null)
        {
            _command.Move(this, _cavern);
            return;
        }

        Display.Error("This command is not supported, press a key to continue...");
    }
}