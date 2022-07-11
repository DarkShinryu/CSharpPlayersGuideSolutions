public class Player
{
    public string Name { get; }
    public Sign Sign { get; }
    public int SelectedSquare { get; private set; }
    public bool IsWinner { get; set; }

    public Player(string name, Sign sign)
    {
        Name = name;
        Sign = sign;
        IsWinner = false;
    }

    public void SetSelectedSquare()
    {
        do
        {
            Console.Write("Select square (from 1 to 9): ");
            int.TryParse(Console.ReadLine(), out int userValue);
            SelectedSquare = userValue;
        } while (SelectedSquare < 1 || SelectedSquare > 9);  // We're using the numpad from 1 to 9 to pick squares

        SelectedSquare--;   // We are using arrays for the board and they're 0-based
    }
}