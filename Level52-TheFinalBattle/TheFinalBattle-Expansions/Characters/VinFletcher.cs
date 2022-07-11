public class VinFletcher : Character
{
    public VinFletcher(string name, int startingExperience, ControlMode controlMode, ConsoleColor color) : base(name, startingExperience, controlMode, color)
    {
        Experience = startingExperience;
        Compiled = true;
    }
}