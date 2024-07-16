using System;

class ex5
{
    static void Main(string[] args)
    {
        Console.Write("Enter the first number: ");
        if (!int.TryParse(Console.ReadLine(), out int num1))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return;
        }

        Console.Write("Enter the second number: ");
        if (!int.TryParse(Console.ReadLine(), out int num2))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return;
        }

        CalculateSumAndDifference(num1, num2, out int sum, out int difference);

        Console.WriteLine($"The sum of {num1} and {num2} is: {sum}");
        Console.WriteLine($"The difference between {num1} and {num2} is: {difference}");
        Console.ReadLine();
    }

    static void CalculateSumAndDifference(int a, int b, out int sum, out int difference)
    {
        sum = a + b;
        difference = a - b;
    }
}
