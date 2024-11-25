using System;
using System.Collections.Generic;
using System.IO;

namespace MiniInventory
{
    public class Inventory
    {
        private List<Item> items;
        public double CarryingCapacity { get; private set; }
        
        public Inventory(double carryingCapacity)
        {
            items = new List<Item>();
            CarryingCapacity = carryingCapacity;
        }

        public bool AddItem(Item item)
        {
            if (GetTotalWeight() + item.Weight > CarryingCapacity)
            {
                Console.WriteLine("Det är för tungt att lägga till.");
                return false;
            }
            items.Add(item);
            return true;
        }

        public void RemoveItem(string itemName)
        {
            items.RemoveAll(i => i.Name == itemName);
        }

        public double GetTotalWeight()
        {
            double totalWeight = 0;
            foreach (var item in items)
                totalWeight += item.Weight;
            return totalWeight;
        }

        public void DisplayItems()
        {
            Console.WriteLine("Inventory:");
            foreach (var item in items)
                Console.WriteLine($"- {item.Name}");
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in items)
                {
                    writer.WriteLine($"{item.GetType().Name},{item.Name},{item.Weight}");
                }
            }
        }

        public void LoadFromFile(string filePath)
        {
            items.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    string type = parts[0];
                    string name = parts[1];
                    double weight = double.Parse(parts[2]);

                    if (type == "Weapon")
                        items.Add(new Weapon(name, weight, 10, 20));
                    else if (type == "Consumable")
                        items.Add(new Consumable(name, weight, 3));
                    else if (type == "Armor")
                        items.Add(new Armor(name, weight));
                }
            }
        }
    }
}
