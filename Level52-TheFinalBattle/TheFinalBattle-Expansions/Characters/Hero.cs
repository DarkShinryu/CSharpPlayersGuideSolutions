public class Hero : Character
{
    public Hero(string name, int startingExperience, ControlMode controlMode, ConsoleColor color) : base(name, startingExperience, controlMode, color)
    {
        AttackModifier = new AttackModifier(AttackModifierType.ObjectSight);
        Experience = startingExperience;
        Compiled = true;
    }
}