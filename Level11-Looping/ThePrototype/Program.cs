int number = int.MinValue;
int guessedNumber = int.MinValue;
bool isGuessCorrect = false;
int attemptsCount = 0;  // Not required by the challenge but makes sense to have it

do
{
    Console.Write("First user, enter a number between 0 and 100: ");
    number = Convert.ToInt32(Console.ReadLine());
} while (number < 0 || number > 100);

Console.Clear();

while (!isGuessCorrect)
{
    attemptsCount++;

    do
    {
        Console.Write("Second user, guess the correct number between 0 and 100: ");
        guessedNumber = Convert.ToInt32(Console.ReadLine());
    } while (guessedNumber < 0 || guessedNumber > 100);

    if (guessedNumber < number) // There's no need to set the bool condition to false in here, it already is.
        Console.WriteLine("Too low.");
    else if (guessedNumber > number)
        Console.WriteLine("Too high.");
    else
        isGuessCorrect = true;
}

Console.WriteLine($"{guessedNumber} is the correct number, it took you {attemptsCount} attempts to get it right.");