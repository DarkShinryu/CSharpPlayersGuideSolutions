Console.WriteLine("The following items are available:\n" +
    "1 - Rope\n" +
    "2 - Torches\n" +
    "3 - Climbing Equipment\n" +
    "4 - Clean Water\n" +
    "5 - Machete\n" +
    "6 - Canoe\n" +
    "7 - Food Supplies\n");

Console.Write("What number do you want to see the price of? ");
int userChoice = int.Parse(Console.ReadLine());


string itemName = string.Empty;
int itemPrice = int.MinValue;

switch (userChoice)
{
    case 1:
        itemName = "Rope";
        itemPrice = 10;
        break;
    case 2:
        itemName = "Torches";
        itemPrice = 15;
        break;
    case 3:
        itemName = "Climbing Equipment";
        itemPrice = 25;
        break;
    case 4:
        itemName = "Clean Water";
        itemPrice = 1;
        break;
    case 5:
        itemName = "Machete";
        itemPrice = 20;
        break;
    case 6:
        itemName = "Canoe";
        itemPrice = 200;
        break;
    case 7:
        itemName = "Food Supplies";
        itemPrice = 1;
        break;
    default:
        break;
}

if (itemName == string.Empty || itemPrice <= 0)
    Console.WriteLine("Sorry, I don't sell that one.");
else
    Console.WriteLine($"{itemName} cost {itemPrice} gold.");