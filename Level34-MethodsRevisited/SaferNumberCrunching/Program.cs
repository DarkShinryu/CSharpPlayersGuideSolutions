int number = GetInt();
Console.WriteLine($"You entered {number}.\n");

double fractional = GetDouble();
Console.WriteLine($"You entered {fractional}.\n");

bool condition = GetBool();
Console.WriteLine($"You entered {condition}.");


int GetInt()
{
    int number;
    do
    {
        Console.Write("Enter an integer: ");
    } while (!int.TryParse(Console.ReadLine(), out number));

    return number;
}

double GetDouble()
{
    double number;
    do
    {
        Console.Write("Enter a number: ");
    } while (!double.TryParse(Console.ReadLine(), out number));

    return number;
}

bool GetBool()
{
    bool condition;
    do
    {
        Console.Write("Enter a boolean value (true or false): ");
    } while (!bool.TryParse(Console.ReadLine(), out condition));

    return condition;
}