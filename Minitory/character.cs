namespace MiniInventory
{
    public class Character
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public Inventory Inventory { get; private set; }

        public Character(string name, int health, double carryingCapacity)
        {
            Name = name;
            Health = health;
            Inventory = new Inventory(carryingCapacity);
        }

        public void IncreaseHealth(int amount)
        {
            Health += amount;
            Console.WriteLine($"{Name} fick {amount} hälsa. Nuvarande hälsa: {Health}");
        }
    }
}
