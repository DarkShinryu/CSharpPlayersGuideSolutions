public class Display
{
    private Game game;
    private List<string> archive = new List<string>();
    public Display(Game game) => this.game = game;

    public void IntroScreen()
    {
        Console.WriteLine("Welcome to Hangman!\n");
        Console.Write("Please, enter your name: ");
    }

    public void MainScreen()
    {
        Console.Clear();
        archive.Add(Current());
        PrintArchive();


        Console.Write($"\n{game.Player.Name}, pick a letter: ");

    }

    public void EndScreen()
    {
        Console.Clear();
        PrintArchive();

        Console.WriteLine($"Word: {GetFormattedWord(game.Word)}");

        if (game.Player.IsWinner)
            Console.WriteLine("\nYou won!");
        else
            Console.WriteLine("\nYou lost!");
    }

    private void PrintArchive()
    {
        foreach (string line in archive)
            Console.WriteLine(line);
    }

    private string GetFormattedWord(string word)
    {
        string tempWord = string.Empty;

        foreach (char letter in word)
            tempWord += letter + " ";

        return tempWord;
    }

    private string GetWrongLetters()
    {
        string wrongLetters = string.Empty;

        wrongLetters += "| Incorrect: ";

        foreach (char letter in game.WrongLetters)
            wrongLetters += letter + " ";

        if (game.WrongLetters.Count == 0)
            wrongLetters += "_ ";

        return wrongLetters;
    }

    private string Current()
    {
        // Word: _ _ _ _ _ _ _ _ _ | Remaining: 5 | Incorrect: | Guess: e
        string current = string.Empty;

        current += "Word: ";
        current += GetFormattedWord(game.GuessWord);
        current += $"| Remaining: {game.RemainingAttempts} ";
        current += GetWrongLetters();
        current += $"| Guess: {game.Player.Letter}";

        return current;
    }
}