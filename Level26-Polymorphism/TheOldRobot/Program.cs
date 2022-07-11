Robot robot = new Robot();

for (int i = 0; i < robot.RobotCommands.Length; i++)
{
    Console.Write("Enter a command: ");
    robot.RobotCommands[i] = (Console.ReadLine() ?? "Unknown").ToLower() switch
    {
        "on"    => new OnCommand(),
        "off"   => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east"  => new EastCommand(),
        "west"  => new WestCommand(),
        _       => null
    };
}

robot.Run();