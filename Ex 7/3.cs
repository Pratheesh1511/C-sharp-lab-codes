using System;
using System.Collections.Generic;

class IntegerStack
{
    Stack<int> stack = new Stack<int>();

    public void Push(int number)
    {
        stack.Push(number);
        Console.WriteLine($"{number} pushed onto the stack.");
    }

    public void Pop()
    {
        if (stack.Count > 0)
        {
            Console.WriteLine($"{stack.Pop()} popped from the stack.");
        }
        else
        {
            Console.WriteLine("Stack is empty.");
        }
    }

    public void Peek()
    {
        if (stack.Count > 0)
        {
            Console.WriteLine($"Top element is {stack.Peek()}.");
        }
        else
        {
            Console.WriteLine("Stack is empty.");
        }
    }

    public void DisplayStack()
    {
        Console.WriteLine("Current Stack:");
        foreach (var number in stack)
        {
            Console.WriteLine(number);
        }
    }
}

class Program
{
    static void Main()
    {
        IntegerStack integerStack = new IntegerStack();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nStack Menu:");
            Console.WriteLine("1. Push");
            Console.WriteLine("2. Pop");
            Console.WriteLine("3. Peek");
            Console.WriteLine("4. Display Stack");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter an integer to push: ");
                    int number = int.Parse(Console.ReadLine());
                    integerStack.Push(number);
                    break;
                case "2":
                    integerStack.Pop();
                    break;
                case "3":
                    integerStack.Peek();
                    break;
                case "4":
                    integerStack.DisplayStack();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
