using System;

namespace MiniInventory
{
    public class Weapon : Item
    {
        private int minDamage;
        private int maxDamage;

        public Weapon(string name, double weight, int minDamage, int maxDamage) : base(name, weight)
        {
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        public int Attack()
        {
            Random rand = new Random();
            return rand.Next(minDamage, maxDamage + 1);
        }
    }
}
