Console.WriteLine("How many chocolate eggs where gathered today?");
int totalEggs = int.Parse(Console.ReadLine());
int sisters = 4;

int eggsPerSister = totalEggs / sisters;
int eggsForDuckbear = totalEggs % sisters;

Console.WriteLine("Each sister gets " + eggsPerSister + " eggs.");
Console.WriteLine("The duckbear gets " + eggsForDuckbear + " eggs.");



// Answer this question: What are three total egg counts where the duckbear gets more than each sister does?

// 6, 7, 11 and all numbers below 4.