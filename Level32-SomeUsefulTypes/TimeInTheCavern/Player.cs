public class Player
{
    private readonly Cavern _cavern;
    private IPlayerCommand? _command;

    public Room CurrentRoom { get; set; }
    public int Arrows { get; set; }
    // Welcome to boolean hell :)
    public bool HasEnabledFountain { get; set; }
    public bool IsAtEntranceRoom => CurrentRoom == _cavern.Entrance;
    public bool IsAtFountainRoom => CurrentRoom == _cavern.Fountain;
    public bool IsNearPitRoom => IsNearDangerousRoom(_cavern.Pits);
    public bool IsNearMaelstromRoom => IsNearDangerousRoom(_cavern.Maelstroms);
    public bool IsNearAmarokRoom => IsNearDangerousRoom(_cavern.Amaroks);
    public bool IsAtPitRoom => IsAtDangerousRoom(_cavern.Pits);
    public bool IsAtMaelstromRoom => IsAtDangerousRoom(_cavern.Maelstroms);
    public bool IsAtAmarokRoom => IsAtDangerousRoom(_cavern.Amaroks);
    public bool IsDead
    {
        get
        {
            if (IsAtPitRoom) return true;
            if (IsAtAmarokRoom) return true;

            return false;
        }
    }

    public Player(Cavern cavern, int arrows)
    {
        _cavern = cavern;
        CurrentRoom = _cavern.Entrance;   // The player starts at the entrance
        Arrows = arrows;
        HasEnabledFountain = false;
    }

    public void Command(string playerCommand)
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

            case "sn":
            case "shoot north":
                _command = new ShootNorthCommand();
                break;

            case "ss":
            case "shoot south":
                _command = new ShootSouthCommand();
                break;

            case "sw":
            case "shoot west":
                _command = new ShootWestCommand();
                break;

            case "se":
            case "shoot east":
                _command = new ShootEastCommand();
                break;

            case "f":
            case "enable fountain":
                _command = new FountainCommand();
                break;

            case "h":
            case "help":
                _command = new HelpCommand();
                break;

            default:
                _command = null;
                break;
        }

        if (_command != null)
        {
            _command.Execute(this, _cavern);
            return;
        }

        Display.Error("This command is not supported, press a key to continue...");
    }

    private bool IsNearDangerousRoom(List<Room> dangerousRooms)
    {
        foreach (Room dangerousRoom in dangerousRooms)
        {
            if (CurrentRoom.Row == dangerousRoom.Row && Math.Abs(CurrentRoom.Col - dangerousRoom.Col) == 1) return true;
            if (CurrentRoom.Col == dangerousRoom.Col && Math.Abs(CurrentRoom.Row - dangerousRoom.Row) == 1) return true;

            // The commented line below includes diagonal rooms, but I feel the player gets easily inundated with messages between pits, maelstroms and amaroks
            // So I'd rather not tell them anything about diagonally adjacent rooms, since the player cannot move diagonally anyway.
            //if (Math.Abs(CurrentRoom.Row - deadlyRoom.Row) <= 1 && Math.Abs(CurrentRoom.Col - deadlyRoom.Col) <= 1 && !deadlyRoom) return true;
        }

        return false;
    }

    private bool IsAtDangerousRoom(List<Room> dangerousRooms)
    {
        foreach (Room dangerousRoom in dangerousRooms)
            if (CurrentRoom == dangerousRoom) return true;

        return false;
    }

    public void Teleport()
    {
        int updatedPlayerRow = Math.Clamp(CurrentRoom.Row - 1, _cavern.OuterWalls.Row.Min, _cavern.OuterWalls.Row.Max);
        int updatedPlayerCol = Math.Clamp(CurrentRoom.Col + 2, _cavern.OuterWalls.Col.Min, _cavern.OuterWalls.Col.Max);
        CurrentRoom = new Room(updatedPlayerRow, updatedPlayerCol);
    }
}