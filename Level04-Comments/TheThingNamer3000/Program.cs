Console.WriteLine("What kind of thing are we talking about?");
string a = Console.ReadLine();  // The name of the object
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
string b = Console.ReadLine();  /* The main charateristic of the object */
string c = "of Doom";   // Not the game!
string d = "3000";  // Big round numbers are cool?
// Console.WriteLine("The " + b + " " + a + " of " + c + " " + d + "!"); wrong line provided by the exercise
Console.WriteLine("The " + b + " " + a + " " + c + " " + d + "!");


// Aside from comments, what else could you do to make this code more understandable?
/*
 * 1. Give variables descriptive names.
 * 2. Variables 'c' and 'd' could probably be joined together.
*/