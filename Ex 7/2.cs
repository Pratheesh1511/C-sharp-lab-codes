using System;
using System.Collections.Generic;

class LibrarySystem
{
    Dictionary<string, bool> library = new Dictionary<string, bool>(); // true means available, false means borrowed

    public void AddBook(string title)
    {
        if (!library.ContainsKey(title))
        {
            library[title] = true;
            Console.WriteLine($"Book '{title}' added to the library.");
        }
        else
        {
            Console.WriteLine($"Book '{title}' already exists in the library.");
        }
    }

    public void BorrowBook(string title)
    {
        if (library.ContainsKey(title) && library[title])
        {
            library[title] = false;
            Console.WriteLine($"You have borrowed '{title}'.");
        }
        else if (!library.ContainsKey(title))
        {
            Console.WriteLine($"Book '{title}' not found in the library.");
        }
        else
        {
            Console.WriteLine($"Book '{title}' is already borrowed.");
        }
    }

    public void ReturnBook(string title)
    {
        if (library.ContainsKey(title) && !library[title])
        {
            library[title] = true;
            Console.WriteLine($"You have returned '{title}'.");
        }
        else if (!library.ContainsKey(title))
        {
            Console.WriteLine($"Book '{title}' not found in the library.");
        }
        else
        {
            Console.WriteLine($"Book '{title}' was not borrowed.");
        }
    }

    public void DisplayBooks()
    {
        Console.WriteLine("Library Inventory:");
        foreach (var book in library)
        {
            Console.WriteLine($"Title: {book.Key}, Available: {(book.Value ? "Yes" : "No")}");
        }
    }
}

class Program
{
    static void Main()
    {
        LibrarySystem librarySystem = new LibrarySystem();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nLibrary System Menu:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Borrow Book");
            Console.WriteLine("3. Return Book");
            Console.WriteLine("4. Display Books");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine();
                    librarySystem.AddBook(title);
                    break;
                case "2":
                    Console.Write("Enter book title to borrow: ");
                    title = Console.ReadLine();
                    librarySystem.BorrowBook(title);
                    break;
                case "3":
                    Console.Write("Enter book title to return: ");
                    title = Console.ReadLine();
                    librarySystem.ReturnBook(title);
                    break;
                case "4":
                    librarySystem.DisplayBooks();
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
