Robot robot = new Robot();

string? robotCommandAsStr;
do
{
    Console.Write("Enter a command: ");
    robotCommandAsStr = Console.ReadLine();

    IRobotCommand? command = robotCommandAsStr switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand(),
        _ => null
    };

    robot.RobotCommands.Add(command);
} while (robotCommandAsStr != "stop");

robot.Run();