Card[,] deck = Card.CreateDeck();
Card.DisplayDeck(deck);

public class Card
{
    // Properties
    public Color Color { get; }
    public Rank Rank { get; }
    public bool IsNumber
    {
        get
        {
            if (Rank <= Rank.Ten) return true;
            return false;
        }
    }
    public bool IsSymbol => !IsNumber;


    // Constructors
    public Card(Color color, Rank rank)
    {
        Color = color;
        Rank = rank;
    }


    // Methods
    public static Card[,] CreateDeck()
    {
        Card[,] deck = new Card[Enum.GetNames(typeof(Color)).Length, Enum.GetNames(typeof(Rank)).Length];
        for (int color = 0; color < deck.GetLength(0); color++)
        {
            for (int rank = 0; rank < deck.GetLength(1); rank++)
                deck[color, rank] = new Card((Color)color, (Rank)rank); // Taking advantage of enums being just ints behind the scene
        }

        return deck;
    }

    public static void DisplayDeck(Card[,] deck)
    {
        for (int color = 0; color < deck.GetLength(0); color++)
        {
            Console.ForegroundColor = deck[color, 0].Color switch
            {
                Color.Red => ConsoleColor.Red,
                Color.Green => ConsoleColor.Green,
                Color.Blue => ConsoleColor.Blue,
                Color.Yellow => ConsoleColor.Yellow,
                _ => ConsoleColor.Gray  // Default color
            };

            for (int rank = 0; rank < deck.GetLength(1); rank++)
                Console.WriteLine($"The {deck[color, rank].Color} {deck[color, rank].Rank}");
        }

        Console.ResetColor();
    }
}


public enum Color { Red , Green, Blue, Yellow }
public enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Caret, Ampersand }
