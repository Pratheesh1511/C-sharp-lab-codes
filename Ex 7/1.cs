using System;
using System.Collections.Generic;

class InventoryItem
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    
    public InventoryItem(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}

class InventorySystem
{
    LinkedList<InventoryItem> inventory = new LinkedList<InventoryItem>();

    public void AddItem(string name, int quantity)
    {
        inventory.AddLast(new InventoryItem(name, quantity));
        Console.WriteLine($"{name} added with quantity {quantity}.");
    }

    public void RemoveItem(string name)
    {
        var item = inventory.First;
        while (item != null)
        {
            if (item.Value.Name == name)
            {
                inventory.Remove(item);
                Console.WriteLine($"{name} removed from inventory.");
                return;
            }
            item = item.Next;
        }
        Console.WriteLine($"{name} not found in inventory.");
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Current Inventory:");
        foreach (var item in inventory)
        {
            Console.WriteLine($"Item: {item.Name}, Quantity: {item.Quantity}");
        }
    }
}

class Program
{
    static void Main()
    {
        InventorySystem inventorySystem = new InventorySystem();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nInventory System Menu:");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Display Inventory");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter item name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    inventorySystem.AddItem(name, quantity);
                    break;
                case "2":
                    Console.Write("Enter item name to remove: ");
                    name = Console.ReadLine();
                    inventorySystem.RemoveItem(name);
                    break;
                case "3":
                    inventorySystem.DisplayInventory();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
