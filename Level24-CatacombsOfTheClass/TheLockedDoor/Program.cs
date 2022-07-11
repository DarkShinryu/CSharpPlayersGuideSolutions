Door door = new Door(Door.GetPasscode("Enter the initial passcode: "));    // By using a static method from the door class our main method is cleaner and we get all the benefits of abstraction

while (true)
{
    Console.WriteLine($"The door is {door.State.ToString().ToLower()}. Enter your command: ");
    Console.WriteLine("1. Open\n" + "2. Close\n" + "3. Lock\n" + "4. Unlock\n" + "5. Change Passcode");
    string userCommand = Console.ReadLine()!.ToLower(); // Handling the null possibility in the default case below
    switch (userCommand)
    {
        case "1":
        case "open":
            door.Open();
            break;
        case "2":
        case "close":
            door.Close();
            break;
        case "3":
        case "lock":
            door.Lock();
            break;
        case "4":
        case "unlock":
            door.Unlock(Door.GetPasscode("Enter the passcode: "));
            break;
        case "5":
        case "change passcode":
            door.ChangePasscode(Door.GetPasscode("Enter the current passcode: "));
            break;
        default:
            break;
    }

    Console.Clear();
}



public class Door
{
    private int passcode;   // This better be private!
    public DoorState State { get; private set; }

    public Door(int passcode)
    {
        this.passcode = passcode;
        State = DoorState.Locked;
    }

    public void Open()
    {
        if (State == DoorState.Closed) State = DoorState.Open;
    }

    public void Close()
    {
        if (State == DoorState.Open) State = DoorState.Closed;
    }

    public void Lock()
    {
        if (State == DoorState.Closed) State = DoorState.Locked;
    }

    public void Unlock(int guessedPasscode)
    {
        if (State == DoorState.Locked && guessedPasscode == passcode) State = DoorState.Closed;
    }

    public void ChangePasscode(int oldPasscode)
    {
        if (oldPasscode == passcode)
        {
            passcode = GetPasscode("Enter the new passcode: ");
            WaitForUserKeyPress("Success");

        }
        else
        {
            WaitForUserKeyPress("Wrong passcode");
        }
    }

    private void WaitForUserKeyPress(string prompt)
    {
        Console.Clear();
        Console.Write(prompt);
        Console.ReadKey(true);
        Console.Clear();
    }

    public static int GetPasscode(string prompt)
    {
        Console.Clear();
        Console.Write(prompt);
        int passcode = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        return passcode;
    }
}

public enum DoorState { Unknown, Locked, Closed, Open }