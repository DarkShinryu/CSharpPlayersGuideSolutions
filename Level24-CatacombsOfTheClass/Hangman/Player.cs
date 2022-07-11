public class Player
{
    public string? Name { get; private set; }
    public char Letter { get; private set; }
    public List<char> UsedLetters { get; }
    public bool IsWinner { get; set; } = false;

    public Player()
    {
        Letter = '_';
        UsedLetters = new List<char>();
    }

    public void SetName()
    {
        do
        {
            Name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(Name));
    }

    public void SetLetter()
    {
        bool IsAlreadyUsed;

        do
        {
            IsAlreadyUsed = false;

            string? letter;
            do
            {
                letter = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(letter)  || letter.Length > 1);

            Letter = Convert.ToChar(letter.ToUpper());

            if (UsedLetters.Count == 0)
            {
                UsedLetters.Add(Letter);
                return;
            }

            foreach (char usedLetter in UsedLetters)
            {
                if (usedLetter == Letter)
                    IsAlreadyUsed = true;
            }

            if (!IsAlreadyUsed)
                UsedLetters.Add(Letter);

        } while (IsAlreadyUsed);
    }
}