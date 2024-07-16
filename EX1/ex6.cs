using System;

class ex6
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

        SwapTwoNumber(num1, num2, out int swap_a, out int swap_b);

        Console.WriteLine($"The swapped number {num1} and {num2} is: {swap_a} and {swap_b}");
        Console.ReadLine();
    }


    static void SwapTwoNumber(int a, int b, out int swap_a, out int swap_b)
    {
       
        int c = a;
        a = b;
        b = c;
        swap_a = a;
        swap_b = b;
        
        
    }
}
