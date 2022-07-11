public class Game
{
    private Display display;

    public string Word { get; }
    public string GuessWord { get; private set; }
    public List<char> WrongLetters { get; private set; }
    public Player Player { get; }
    public int RemainingAttempts { get; private set; }
    public bool IsGameOver { get; private set; }

    public Game()
    {
        Dictionary dictionary = new Dictionary();
        Random random = new Random();

        Word = dictionary.Words[random.Next(dictionary.Words.Length)].ToUpper();
        GuessWord = new string('_', Word.Length);   // Neat!
        WrongLetters = new List<char>();
        Player = new Player();
        RemainingAttempts = 5;
        IsGameOver = false;
        display = new Display(this);
    }

    public void Run()
    {
        display.IntroScreen();
        Player.SetName();

        while (!IsGameOver)
        {
            display.MainScreen();
            Player.SetLetter();
            CheckLetter();
            CheckWinner();
        }

        display.EndScreen();
    }

    private void CheckWinner()
    {
        if (string.Equals(Word, GuessWord) || RemainingAttempts <= 0)
        {
            IsGameOver = true;

            if (RemainingAttempts >= 1)
                Player.IsWinner = true;
        }
    }

    private void CheckLetter()
    {
        bool IsLetterPresent = false;
        string updatedGuessWord = string.Empty;

        for (int i = 0; i < Word.Length; i++)
        {
            if (Word[i] == Player.Letter)
            {
                updatedGuessWord += Player.Letter;
                IsLetterPresent = true;
            }
            else
            {
                if (GuessWord[i] == '_')
                    updatedGuessWord += '_';
                else
                    updatedGuessWord += GuessWord[i];
            }
        }

        if (IsLetterPresent)
        {
            GuessWord = updatedGuessWord;
        }
        else
        {
            AddWrongLetter(Player.Letter);
            RemainingAttempts--;
        }
    }

    private void AddWrongLetter(char wrongLetter)
    {
        bool IsAlreadyPresent = false;
        for (int i = 0; i < WrongLetters.Count; i++)
        {
            if (WrongLetters[i] == wrongLetter)
            {
                IsAlreadyPresent = true;
                break;
            }
        }

        if (!IsAlreadyPresent)
            WrongLetters.Add(wrongLetter);
    }
}