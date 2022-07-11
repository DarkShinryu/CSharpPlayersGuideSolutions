Console.Write("Enter x: ");
int x = int.Parse(Console.ReadLine());
Console.Write("Enter y: ");
int y = int.Parse(Console.ReadLine());

string output = "The enemy is to the ";

if (x < 0)
{
    if (y > 0)
        output += "Northwest!";
    else if (y < 0)
        output += "Southwest!";
    else
        output += "West!";
}
else if (x > 0)
{
    if (y > 0)
        output += "Northeast!";
    else if (y < 0)
        output += "Southeast!";
    else
        output += "East!";
}
else
{
    if (y > 0)
        output += "North!";
    else if (y < 0)
        output += "South!";
    else
        output = "The enemy is here!";
}

Console.WriteLine(output);