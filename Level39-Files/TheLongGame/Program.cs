Console.Write("Enter your name: ");
Player player = new Player(Console.ReadLine() ?? "Player", 0);

if (File.Exists($"{player.Name}.txt"))
{
    string scoreAsStr = File.ReadAllText($"{player.Name}.txt");
    scoreAsStr = scoreAsStr.TrimStart((player.Name + ',').ToCharArray());

    player.Score = Convert.ToInt32(scoreAsStr);
}

while (player.Key != ConsoleKey.Enter)
{
    Console.Clear();
    Console.WriteLine($"Score: {player.Score}");

    Console.Write("Press a key...");
    player.Key = Console.ReadKey(true).Key;

    if (player.Key != null)
        player.Score++;
}

File.WriteAllText($"{player.Name}.txt", $"{player.Name},{player.Score}");

Console.Clear();
Console.WriteLine($"Score of {player.Score} saved to { player.Name}.txt");

public class Player
{
    public string Name { get; }
    public int Score { get; set; }
    public ConsoleKey? Key { get; set; }

    public Player(string name, int score)
    {
        Name = name;
        Score = score;
    }
}