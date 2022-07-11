ChestState chest = ChestState.Locked;

while (true)
{
    Console.Write($"The chest is {chest}. Enter a command (lock, unlock, open, close): ");
    string userCommand = Console.ReadLine().ToLower();

    switch (userCommand)
    {
        case "lock":
            if (chest == ChestState.Closed) chest = ChestState.Locked;
            break;
        case "unlock":
            if (chest == ChestState.Locked) chest = ChestState.Closed;
            break;
        case "open":
            if (chest == ChestState.Closed) chest = ChestState.Open;
            break;
        case "close":
            if (chest == ChestState.Open) chest = ChestState.Closed;
            break;
        default:
            Console.WriteLine("Invalid command, try again.");
            break;
    }
}


enum ChestState { Open, Closed, Locked}