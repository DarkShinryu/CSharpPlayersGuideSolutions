dynamic intAddition = Add(2, 5);
dynamic doubleAddition = Add(1.2, 0.4);
dynamic stringAddition = Add("Hello, ", "world.");
dynamic dateTimeAddition = Add(DateTime.Now, TimeSpan.FromDays(1));

Console.WriteLine(intAddition);
Console.WriteLine(doubleAddition);
Console.WriteLine(stringAddition);
Console.WriteLine(dateTimeAddition);


dynamic Add(dynamic a, dynamic b) => a + b;


// The compiler can't tell if the types support the + operator.
// For example if I try to add a bool to a TimeSpan the program would crash.