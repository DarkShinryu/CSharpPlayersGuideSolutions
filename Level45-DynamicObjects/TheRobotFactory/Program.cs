using System.Dynamic;

Console.Write("How many robots do you want to build? ");
dynamic robotCount = Convert.ToInt32(Console.ReadLine());
Console.Clear();

List<dynamic> robots = new List<dynamic>(robotCount);

for (int i = 1; i <= robots.Capacity; i++)
{
    dynamic robot = new ExpandoObject();

    robot.Id = i;   // Ideally it would be better to store the Ids somewhere, like this we always start from 1 every time we run the program
    Console.WriteLine($"You are producing robot #{robot.Id}");

    HandleName(robot);
    HandleSize(robot);
    HandleColor(robot);
    Console.Clear();

    robots.Add(robot);
}


foreach (dynamic robot in robots)
{
    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
        Console.WriteLine($"{property.Key}: {property.Value}");

    Console.WriteLine();
}


void HandleName(dynamic robot)
{
    Console.Write("Do you want to name the robot? ");
    if (Console.ReadLine()?.ToLower() == "yes")
    {
        Console.Write("Enter the robot's name: ");
        robot.Name = Console.ReadLine();
    }
}

void HandleSize(dynamic robot)
{
    Console.Write("Does this robot have a specific size? ");
    if (Console.ReadLine()?.ToLower() == "yes")
    {
        Console.Write("Enter the robot's height: ");
        robot.Height = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the robot's width: ");
        robot.Width = Convert.ToDouble(Console.ReadLine());
    }
}

void HandleColor(dynamic robot)
{
    Console.Write("Does this robot need to be a specific color? ");
    if (Console.ReadLine()?.ToLower() == "yes")
    {
        Console.Write("Enter the robot's color: ");
        robot.Color = Console.ReadLine();
    }
}