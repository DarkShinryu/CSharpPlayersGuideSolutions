Sieve sieve = new Sieve(Sieve.GetFilter());
Console.Clear();

while (true)
{
    if (sieve.IsGood(GetNumber()))
    {
        Console.WriteLine("That's a good number.");
        continue;
    }

    Console.WriteLine("That's a bad number.");
}

int GetNumber()
{
    int number;

    do
    {
        Console.Write("Enter a number: ");
    } while (!int.TryParse(Console.ReadLine(), out number));

    return number;
}


public class Sieve
{
    private Predicate<int> _filter;

    public Sieve(Predicate<int> filter) => _filter = filter;

    public bool IsGood(int number) => _filter(number);

    private static bool IsEven(int number) => number % 2 == 0;
    private static bool IsPositive(int number) => number >= 0;
    private static bool IsMultipleOf10(int number) => number % 10 == 0;

    public static Predicate<int> GetFilter()
    {
        Predicate<int>? filter;

        do
        {
            Console.Write("Enter the filter you want to use ('Even', 'Positive', 'Multiple10'): ");

            filter = Console.ReadLine()?.ToLower() switch
            {
                "even" => IsEven,
                "positive" => IsPositive,
                "multiple10" => IsMultipleOf10,
                _ => null
            };
        } while (filter == null);

        return filter;
    }
}