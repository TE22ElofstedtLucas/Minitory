namespace MiniInventory
{
    public class Consumable : Item
    {
        private int usesRemaining;

        public Consumable(string name, double weight, int uses) : base(name, weight)
        {
            usesRemaining = uses;
        }

        public void Use(Character target)
        {
            if (usesRemaining > 0)
            {
                target.IncreaseHealth(10);
                usesRemaining--;
                Console.WriteLine($"{Name} användes, {usesRemaining} användningar kvar.");
            }
            else
            {
                Console.WriteLine($"{Name} är slut.");
            }
        }
    }
}
