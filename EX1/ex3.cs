using System;

class ex3
{
    static void Main(string[] args)
    {
        while (true)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            if (choice == "5")
            {
                Console.WriteLine("Exiting the calculator. Goodbye!");
                break;
            }

            Console.Write("Enter the first number: ");
            if (!double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            Console.Write("Enter the second number: ");
            if (!double.TryParse(Console.ReadLine(), out double num2))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }
            Console.ReadLine();

            double result = 0;
            bool validChoice = true;

            switch (choice)
            {
                case "1":
                    result = Add(num1, num2);
                    break;
                case "2":
                    result = Subtract(num1, num2);
                    break;
                case "3":
                    result = Multiply(num1, num2);
                    break;
                case "4":
                    result = Divide(num1, num2);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    validChoice = false;
                    break;
            }

            if (validChoice)
            {
                Console.WriteLine($"The result is: {result}");
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\nInteractive Calculator Menu:");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option (1-5): ");
    }

    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
            return 0;
        }
        return a / b;
    }
}
