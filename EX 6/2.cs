using System;

class Program
{
    static void Main()
    {
        // Take input from the user
        Console.Write("Enter the first string (a): ");
        string a = Console.ReadLine();

        Console.Write("Enter the second string (b): ");
        string b = Console.ReadLine();

        // Call the comboString function with user input and print the result
        string result = comboString(a, b);
        Console.WriteLine($"Result: {result}");
    }

    static string comboString(string a, string b)
    {
        // Determine which string is shorter and which is longer
        if (a.Length < b.Length)
        {
            return a + b + a;
        }
        else
        {
            return b + a + b;
        }
    }
}
