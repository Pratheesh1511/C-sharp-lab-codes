using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Take input from the user
        Console.Write("Enter a string: ");
        string userInput = Console.ReadLine();

        // Call the countCode function with user input and print the result
        int result = countCode(userInput);
        Console.WriteLine($"The number of times 'co_e' appears in the string is: {result}");
    }

    static int countCode(string input)
    {
        // Regular expression pattern to match "co_e" with any character in place of 'd'
        string pattern = @"co.e";

        // Find matches using Regex and count them
        MatchCollection matches = Regex.Matches(input, pattern);
        return matches.Count;
    }
}
