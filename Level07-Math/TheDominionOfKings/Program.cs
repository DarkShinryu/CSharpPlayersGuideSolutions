Console.Write("Enter the amount of estates: ");
int estatesCount = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the amount of duchies: ");
int duchiesCount = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the amount of provinces: ");
int provincesCount = Convert.ToInt32(Console.ReadLine());

int totalPoints = (estatesCount * 1) + (duchiesCount * 3) + (provincesCount * 6);

Console.WriteLine("Total points: " + totalPoints);