using System;

class ex2
{
    static void Main(string[] args)
    {
        Console.Write("Enter the first number: ");
        if (int.TryParse(Console.ReadLine(), out int start))
        {
            Console.Write("Enter the second number: ");
            if (int.TryParse(Console.ReadLine(), out int end))
            {
                Console.WriteLine($"Prime numbers between {start} and {end} are:");
                PrintPrimeNumbers(start, end);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        Console.ReadLine();
    }

    static void PrintPrimeNumbers(int start, int end)
    {
        for (int i = Math.Min(start, end); i <= Math.Max(start, end); i++)
        {
            if (IsPrime(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }
        for (int i = 2; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}
