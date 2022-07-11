Console.Title = "The Defense of Consolas";

Console.Write("Target row: ");
int row = int.Parse(Console.ReadLine());
Console.Write("Target column: ");
int col = int.Parse(Console.ReadLine());

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Deploy to: ");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"{row}, {col - 1}");
Console.WriteLine($"{row}, {col + 1}");
Console.WriteLine($"{row - 1}, {col}");
Console.WriteLine($"{row + 1}, {col}");

Console.ResetColor();