Random random = new Random();

Console.WriteLine($"{random.NextDouble(10)}:#.###");

Console.WriteLine(random.NextString("Up", "Down", "Left", "Right"));

string coinSide = random.CoinFlip() ? "Heads" : "Tails";
Console.WriteLine($"{coinSide}");


public static class RandomExtensions
{
    public static double NextDouble(this Random random, double max) => random.NextDouble() * max;

    public static string NextString(this Random random, params string[] choices) => choices[random.Next(choices.Length)];

    public static bool CoinFlip(this Random random, double odds = 0.5) => random.NextDouble() < odds;
}