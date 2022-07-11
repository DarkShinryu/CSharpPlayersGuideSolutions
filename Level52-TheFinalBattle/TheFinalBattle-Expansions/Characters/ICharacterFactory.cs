public interface ICharacterFactory
{
    Character CreateCharacter(string name, int startingExperience, ControlMode controlMode);
}

public class HeroFactory : ICharacterFactory
{
    public Character CreateCharacter(string name, int startingExperience, ControlMode controlMode)
        => new Hero(name, startingExperience, controlMode, ConsoleColor.Blue);
}

public class VinFletcherFactory: ICharacterFactory
{
    public Character CreateCharacter(string name, int startingExperience, ControlMode controlMode)
        => new VinFletcher(name, startingExperience, controlMode, ConsoleColor.DarkGreen);
}

public class MylaraAndSkorinFactory : ICharacterFactory
{
    public Character CreateCharacter(string name, int startingExperience, ControlMode controlMode)
        => new MylaraAndSkorin(name, startingExperience, controlMode, ConsoleColor.DarkYellow);
}

public class SkeletonFactory : ICharacterFactory
{
    public Character CreateCharacter(string name, int startingExperience, ControlMode controlMode)
        => new Skeleton(name, startingExperience, controlMode, ConsoleColor.Yellow);
}

public class StoneAmarokFactory : ICharacterFactory
{
    public Character CreateCharacter(string name, int startingExperience, ControlMode controlMode)
        => new StoneAmarok(name, startingExperience, controlMode, ConsoleColor.DarkCyan);
}

public class BitDragonFactory : ICharacterFactory
{
    public Character CreateCharacter(string name, int startingExperience, ControlMode controlMode)
        => new BitDragon(name, startingExperience, controlMode, ConsoleColor.DarkRed);
}

public class UncodedOneFactory : ICharacterFactory
{
    public Character CreateCharacter(string name, int startingExperience, ControlMode controlMode)
        => new UncodedOne(name, startingExperience, controlMode, ConsoleColor.Magenta);
}