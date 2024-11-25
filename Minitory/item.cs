namespace MiniInventory
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public double Weight { get; protected set; }

        public Item(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
