using StackCalc;

Calc calc = new(new LinkedStack());

Console.WriteLine("Input string to evaluate:");
string input = Console.ReadLine() ?? "0";

Console.WriteLine(calc.Evaluate(input));
