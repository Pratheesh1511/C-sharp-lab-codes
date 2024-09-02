using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Example input string
        string input = "121 999 911 1234567890, 9991234567,2468643876, 1357909870, 9991234567, 1234543789";

        // a. Extract all the 10-digit numbers and display them
        Console.WriteLine("a. Extract all 10-digit numbers:");
        var tenDigitNumbers = Regex.Matches(input, @"\b\d{10}\b")
                                    .Cast<Match>()
                                    .Select(m => m.Value)
                                    .ToList();
        foreach (var number in tenDigitNumbers)
            Console.WriteLine(number);
        
        // b. Display all the numbers which have a prefix of 999
        Console.WriteLine("\nb. Numbers with a prefix of 999:");
        var numbersWithPrefix999 = tenDigitNumbers.Where(num => num.StartsWith("999")).ToList();
        foreach (var number in numbersWithPrefix999)
            Console.WriteLine(number);

        // c. Display all the numbers ending with 0
        Console.WriteLine("\nc. Numbers ending with 0:");
        var numbersEndingWith0 = tenDigitNumbers.Where(num => num.EndsWith("0")).ToList();
        foreach (var number in numbersEndingWith0)
            Console.WriteLine(number);

        // d. Replace all the even numbers with 1 and display the result
        Console.WriteLine("\nd. Replace all even numbers with 1:");
        var replacedEvenNumbers = tenDigitNumbers.Select(num => Regex.Replace(num, "[02468]", "1")).ToList();
        foreach (var number in replacedEvenNumbers)
            Console.WriteLine(number);

        // e. Display all the duplicate numbers
        Console.WriteLine("\ne. Display duplicate numbers:");
        var duplicateNumbers = tenDigitNumbers.GroupBy(num => num)
                                             .Where(g => g.Count() > 1)
                                             .Select(g => g.Key)
                                             .ToList();
        foreach (var number in duplicateNumbers)
            Console.WriteLine(number);

        // f. Concatenate any two numbers and display the result
        Console.WriteLine("\nf. Concatenate two numbers:");
        if (tenDigitNumbers.Count >= 2)
        {
            string concatenatedNumbers = tenDigitNumbers[0] + tenDigitNumbers[1];
            Console.WriteLine(concatenatedNumbers);
        }
        else
        {
            Console.WriteLine("Not enough numbers to concatenate.");
        }

        // g. Take any given number, if there is a repeating digit, return the last occurrence of that digit in the number.
        Console.WriteLine("\ng. Last occurrence of a repeating digit in a number:");
        string sampleNumber = "1234567890"; // Example
        char digitToFind = '1'; // Example digit
        int lastOccurrence = sampleNumber.LastIndexOf(digitToFind);
        if (lastOccurrence != -1)
            Console.WriteLine($"Last occurrence of {digitToFind} in {sampleNumber} is at index: {lastOccurrence}");
        else
            Console.WriteLine($"{digitToFind} does not occur in {sampleNumber}");

        // h. Insert 0 at the beginning of the 10-digit numbers
        Console.WriteLine("\nh. Insert 0 at the beginning of 10-digit numbers:");
        var numbersWithZeroPrepended = tenDigitNumbers.Select(num => "0" + num).ToList();
        foreach (var number in numbersWithZeroPrepended)
            Console.WriteLine(number);

        // i. Find out the first occurrence of a given digit in a given number
        Console.WriteLine("\ni. First occurrence of a given digit in a given number:");
        string givenNumber = "1234567890"; // Example
        char digitToFindFirst = '5'; // Example digit
        int firstOccurrence = givenNumber.IndexOf(digitToFindFirst);
        if (firstOccurrence != -1)
            Console.WriteLine($"First occurrence of {digitToFindFirst} in {givenNumber} is at index: {firstOccurrence}");
        else
            Console.WriteLine($"{digitToFindFirst} does not occur in {givenNumber}");

        // j. List all the numbers that have a substring 78 in them
        Console.WriteLine("\nj. Numbers containing the substring '78':");
        var numbersWithSubstring78 = tenDigitNumbers.Where(num => num.Contains("78")).ToList();
        foreach (var number in numbersWithSubstring78)
            Console.WriteLine(number);
    }
}
