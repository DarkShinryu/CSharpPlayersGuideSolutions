public class MylaraAndSkorin : Character    // Let's pretend they're kids and only fight together
{
    public MylaraAndSkorin(string name, int startingExperience, ControlMode controlMode, ConsoleColor color) : base(name, startingExperience, controlMode, color)
    {
        Experience = startingExperience;
        Compiled = true;
    }
}