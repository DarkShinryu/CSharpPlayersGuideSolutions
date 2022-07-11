Console.Title = "Hunting the Manticore";

// Declaring and initializing all needed variables
int shipCurrentHealth = 10;
int shipMaxHealth = shipCurrentHealth;
int shipPosition = 0;
int cityCurrentHealth = 15;
int cityMaxHealth = cityCurrentHealth;
int cityCannonAttack = 0;
int cityCannonRange = 0;
int turn = 0;
bool gameOver = false;


// 1st Player Turn
Console.Write("Player 1, how far away from the city do you want to station the Manticore? ");
shipPosition = GetNumberInRange(0, 100);
Console.Clear();

// 2nd Player Turn
while (!gameOver)
{
    // Setting the turn up
    turn++;
    DisplayGameStatus(turn, cityCurrentHealth, cityMaxHealth, shipCurrentHealth, shipMaxHealth);

    // Cannon Stuff
    cityCannonAttack = GetCannonAttack(turn);
    Console.WriteLine($"The cannon is expected to deal {cityCannonAttack} damage this turn.");
    Console.Write("Enter desired cannon range: ");
    cityCannonRange = GetNumberInRange(0, 100);
    DisplayCannonShotResult(shipPosition, cityCannonRange);

    // Damage Application
    shipCurrentHealth -= ShipDamage(shipPosition, cityCannonRange, cityCannonAttack);
    if (shipCurrentHealth > 0) cityCurrentHealth--;

    // Gameover check
    if (shipCurrentHealth <= 0 || cityCurrentHealth <= 0)
    {
        gameOver = true;

        // Making sure the health values are not below 0 for proper display output in end game
        shipCurrentHealth = Math.Clamp(shipCurrentHealth, 0, shipMaxHealth);
        cityCurrentHealth = Math.Clamp(cityCurrentHealth, 0, cityMaxHealth);
    }
}


// End game screen
Console.WriteLine();
DisplayGameStatus(turn, cityCurrentHealth, cityMaxHealth, shipCurrentHealth, shipMaxHealth);
DisplayEndMessage(shipCurrentHealth, cityCurrentHealth);
Console.Beep();



// Methods
int GetNumberInRange(int min, int max)
{
    int number;
    do
    {
        number = Convert.ToInt32(Console.ReadLine());
    } while (number < min || number > max);

    return number;
}

int GetCannonAttack(int turn)
{
    if (turn % 3 == 0 & turn % 5 == 0)
        return 10;
    else if (turn % 3 == 0 || turn % 5 == 0)
        return 3;
    else
        return 1;
}

void DisplayGameStatus(int turn, int cityCurrentHealth, int cityMaxHealth, int shipCurrentHealth, int shipMaxHealth)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"STATUS: Turn: {turn} City: {cityCurrentHealth}/{cityMaxHealth} Manticore: {shipCurrentHealth}/{shipMaxHealth}");
    Console.ResetColor();
}

void DisplayCannonShotResult(int shipPosition, int cityCannonRange)
{
    if (cityCannonRange == shipPosition)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("That round was a DIRECT HIT!");
    }
    else if (cityCannonRange > shipPosition)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That round OVERSHOT the target.");
    }
    else if (cityCannonRange < shipPosition)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("That round FELL SHORT of the target.");
    }

    Console.ResetColor();
}

int ShipDamage(int shipPosition, int cityCannonRange, int cityCannonAttack)
{
    if (shipPosition == cityCannonRange)
        return cityCannonAttack;
    else
        return 0;
}

void DisplayEndMessage(int shipCurrentHealth, int cityCurrentHealth)
{
    if (shipCurrentHealth <= 0 && cityCurrentHealth > 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The city of Consolas has been destroyed! The uncoded one has won...");
    }

    Console.ResetColor();
    Console.Beep();
}