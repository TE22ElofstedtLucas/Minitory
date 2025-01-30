using System;

namespace MiniInventory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initiera spelaren och inventory
            Character player = new Character("Hero", 100, 50);
            player.Inventory.AddItem(new Weapon("Sword", 5, 10, 15));
            player.Inventory.AddItem(new Consumable("Healing Potion", 1, 3));

            // Visa nuvarande inventory
            player.Inventory.DisplayItems();

            // Fråga om spelaren vill plocka upp ett föremål
            Console.WriteLine("Du hittar en hjälm. Vill du plocka upp den? (ja/nej)");
            string input = Console.ReadLine();
            if (input.ToLower() == "ja")
            {
                player.Inventory.AddItem(new Armor("Helmet", 3));
                Console.WriteLine("Hjälm har lagts till i inventoryt!");
            }

            // Lägg till fler alternativ att plocka upp rustningsdelar
            Console.WriteLine("Välj en rustning att plocka upp: 1. Sköld, 2. Bröstplåt, 3. Stövlar, 4. Ring");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    player.Inventory.AddItem(new Armor("Shield", 8));
                    Console.WriteLine("Sköld har lagts till i inventoryt!");
                    break;
                case 2:
                    player.Inventory.AddItem(new Armor("Chestplate", 12));
                    Console.WriteLine("Bröstplåt har lagts till i inventoryt!");
                    break;
                case 3:
                    player.Inventory.AddItem(new Armor("Boots", 4));
                    Console.WriteLine("Stövlar har lagts till i inventoryt!");
                    break;
                case 4:
                    player.Inventory.AddItem(new Accessory("Ring of Strength", 2));
                    Console.WriteLine("Ring har lagts till i inventoryt!");
                    break;
            }

            // Visa nuvarande inventory igen
            player.Inventory.DisplayItems();

            // Spara och ladda inventory från fil
            string filePath = "inventory.txt";
            player.Inventory.SaveToFile(filePath);
            Console.WriteLine("Inventory sparat till fil.");

            // Ladda inventory från fil
            player.Inventory.LoadFromFile(filePath);
            Console.WriteLine("Inventory laddat från fil.");
            player.Inventory.DisplayItems();
        }
    }
}