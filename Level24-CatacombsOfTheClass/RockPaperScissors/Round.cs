public class Round
{
    private Player[] players;
    private bool isDraw = false;

    public int TotalRounds { get; private set; } = 0;

    public Round(Player[] players) => this.players = players;

    public void Run()
    {
        TotalRounds++;

        if (players[0].Shape == players[1].Shape)
            isDraw = true;

        if (!isDraw)
        {
            switch (players[0].Shape)
            {
                case HandShape.Rock:
                    if      (players[1].Shape == HandShape.Paper)    players[1].HasWonRound = true;
                    else if (players[1].Shape == HandShape.Scissors) players[0].HasWonRound = true;
                    break;
                case HandShape.Paper:
                    if      (players[1].Shape == HandShape.Rock)     players[0].HasWonRound = true;
                    else if (players[1].Shape == HandShape.Scissors) players[1].HasWonRound = true;
                    break;
                case HandShape.Scissors:
                    if      (players[1].Shape == HandShape.Rock)     players[1].HasWonRound = true;
                    else if (players[1].Shape == HandShape.Paper)    players[0].HasWonRound = true;
                    break;
                default:
                    break;
            }

            foreach (Player player in players)
            {
                if (player.HasWonRound)
                    player.WinCount++;
            }
        }

        DisplayResult();
        ResetResults();    // Needed for next rounds
    }

    private void DisplayResult()
    {
        // Displaying hand shapes
        foreach (Player player in players)
            Console.WriteLine($"{player.Name}: {player.Shape}!");

        Console.WriteLine();

        // Displaying who won
        if (isDraw)
        {
            Console.WriteLine("This round ended in a draw.");
            return;
        }

        foreach (Player player in players)
            if (player.HasWonRound) Console.WriteLine($"{player.Name} has won!");
    }

    private void ResetResults()
    {
        foreach (Player player in players)
            player.HasWonRound = false;

        isDraw = false;
    }
}