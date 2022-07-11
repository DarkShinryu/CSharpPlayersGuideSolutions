public interface ICharacterFactory
{
    Character CreateCharacter(string name);
}

public class HeroFactory : ICharacterFactory
{
    public Character CreateCharacter(string name) => new Hero(name, ConsoleColor.Green, 25, GetControlMode());

    private ControlMode GetControlMode()
    {
        ControlMode controlMode;

        string? cModeStr;
        do
        {
            Console.Write("Enter the control mode for your characters (1 - Manual | 2 - Auto): ");
            cModeStr = Console.ReadLine()?.ToLower();
            controlMode = cModeStr switch
            {
                "1" or "manual" => ControlMode.Manual,
                "2" or "auto"   => ControlMode.Automated,
                _               => ControlMode.Manual
            };
        } while (string.IsNullOrWhiteSpace(cModeStr) || (cModeStr != "1" && cModeStr != "manual" && cModeStr != "2" && cModeStr != "auto"));

        Console.Clear();

        return controlMode;
    }
}

public class SkeletonFactory : ICharacterFactory
{
    public Character CreateCharacter(string name) => new Skeleton(name, ConsoleColor.Yellow, 5);
}

public class BossFactory : ICharacterFactory
{
    public Character CreateCharacter(string name) => new Boss(name, ConsoleColor.Blue, 15);
}