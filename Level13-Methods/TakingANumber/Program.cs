int firstNumber = AskForNumber("Enter a number: ");
int secondNumber = AskForNumberInRange("Enter a number between 5 and 18: ", 5, 18);

Console.WriteLine($"You entered the numbers {firstNumber} and {secondNumber}.");


int AskForNumber(string text)
{
    while (true)
    {
        Console.Write(text);
        string userInput = Console.ReadLine();

        if (userInput != null || userInput != string.Empty)
            return Convert.ToInt32(userInput);
        else
            Console.WriteLine("Not a valid number, try again.");
    }
}

int AskForNumberInRange(string text, int min, int max)
{
    int number;
    do
    {
        Console.Write(text);
        number = Convert.ToInt32(Console.ReadLine());
    } while (number < min || number > max);

    return number;
}