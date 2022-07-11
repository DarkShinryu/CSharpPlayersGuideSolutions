Console.WriteLine("This program calculates the area of a given triangle.\n");

Console.Write("Enter the base: ");
float length = float.Parse(Console.ReadLine());
Console.Write("Enter the height: ");
float height = float.Parse(Console.ReadLine());

float area = length * height / 2;

Console.WriteLine("Area: " + area);