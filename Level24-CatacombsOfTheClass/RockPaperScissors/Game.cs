public class Game
{
    private Player[] players;
    private Round round;
    private bool isGameOver;
    private int drawCount;

    public Game()
    {
        players = new Player[2] { new Player("Player 1"), new Player("Player 2") };
        round = new Round(players);
        isGameOver = false;
        drawCount = 0;
    }

    public void Run()
    {
        while (!isGameOver)
        {
            GetShapes();
            round.Run();
            GameOverCheck();
        }

        DisplayEndGameResult();
    }

    private void GetShapes()
    {
        foreach (Player player in players)
        {
            do
            {
                Console.WriteLine("1. Rock | 2. Paper | 3. Scissors");
                Console.Write($"{player.Name}, enter your move: ");
                player.SetShape(Console.ReadLine() ?? string.Empty);
                Console.Clear();
            } while (player.Shape == HandShape.Unknown);
        }
    }

    private void GameOverCheck()
    {
        Console.WriteLine('\n');
        Console.Write("Type 'exit' to quit or anything else to continue: ");
        string userInput = Console.ReadLine() ?? string.Empty;

        if (userInput.ToLower() == "exit")
            isGameOver = true;

        Console.Clear();
    }

    private void DisplayEndGameResult()
    {
        drawCount = round.TotalRounds;

        foreach (Player player in players)
        {
            Console.WriteLine($"{player.Name} Total Wins: {player.WinCount}.");
            drawCount -= player.WinCount;   // draws = TotalRounds - PlayersWins
        }
        Console.WriteLine($"Total Draws: {drawCount}.");
    }
}