public class BitDragon : Character
{
    public BitDragon(string name, int startingExperience, ControlMode controlMode, ConsoleColor color) : base(name, startingExperience, controlMode, color)
    {
        ExperienceGiven = 3000;

        Compiled = false;
        Action = new ClawAction();
    }

    protected override void AutomatedAction(Battle battle)
    {
        if (Health.Percentage <= 0.2)
        {
            Action = new BitBreathAction();
            return;
        }

        Action = _random.Next(1, 11) % 4 == 0 ? new BitBreathAction() : new ClawAction();
    }
}