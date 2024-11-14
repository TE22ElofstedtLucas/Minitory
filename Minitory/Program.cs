using System;
using System.Collections.Generic;

public class Item
{
    public string Name { get; }
    public Item(string name) => Name = name;
}

public class Weapon : Item
{
    private int MinDamage { get; }
    private int MaxDamage { get; }
    public Weapon(string name, int minDamage, int maxDamage) : base(name) =>
        (MinDamage, MaxDamage) = (minDamage, maxDamage);

    public int Attack() => new Random().Next(MinDamage, MaxDamage + 1);
}

public class Consumable : Item
{
    private int Uses { get; set; }
    public Consumable(string name, int uses) : base(name) => Uses = uses;

    public void Use(Player target)
    {
        if (Uses-- > 0)
        {
            target.HP += 10;
            Console.WriteLine($"{Name} used. {target.Name}'s HP is now {target.HP}. Uses left: {Uses}");
        }
        else
            Console.WriteLine($"{Name} is out of uses.");
    }
}

public class Inventory
{
    private List<Item> Items { get; } = new();
    public void AddItem(Item item) => Items.Add(item);
    public void Display()
    {
        Console.WriteLine("Current Inventory:");
        Items.ForEach(item => Console.WriteLine($"- {item.Name}"));
    }
}

public class Player
{
    public string Name { get; }
    public int HP { get; set; } = 100;
    public Inventory Inventory { get; } = new();
    public Player(string name) => Name = name;
}

public class Program
{
    public static void Main()
    {
        Player player = new("Player 1");
        player.Inventory.AddItem(new Weapon("Sword", 5, 15));
        player.Inventory.AddItem(new Consumable("Healing Potion", 3));
        player.Inventory.Display();

        Console.Write("You found a new Helmet. Do you want to pick it up? (yes/no): ");
        if (Console.ReadLine().Trim().ToLower() == "yes")
        {
            player.Inventory.AddItem(new Item("Helmet"));
            Console.WriteLine("Helmet added to your inventory.");
        }

        player.Inventory.Display();
    }
}
