public class Player
{
    public string Name { get; }
    public HandShape Shape { get; private set; }
    public bool HasWonRound { get; set; }
    public int WinCount { get; set; }

    public Player(string name)
    {
        Name = name;
        Shape = HandShape.Unknown;
        HasWonRound = false;
        WinCount = 0;
    }

    public void SetShape(string input)
    {
        switch (input.ToLower())
        {
            case "1":
            case "rock":
                Shape = HandShape.Rock;
                break;
            case "2":
            case "paper":
                Shape = HandShape.Paper;
                break;
            case "3":
            case "scissors":
                Shape = HandShape.Scissors;
                break;
            default:
                Shape = HandShape.Unknown;
                break;
        }
    }
}