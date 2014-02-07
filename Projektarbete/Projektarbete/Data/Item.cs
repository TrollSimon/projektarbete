using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projektarbete.Data
{
    public class Item
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public int Health { get; private set; }
        public int AttackPower { get; private set; }
        public int Speed { get; private set; }
        public int CriticalHitChance { get; private set; }

        public Item(string name, string desc, int health, int attack, int speed, int crit)
        {
            Name = name;
            Description = desc;
            Health = health;
            AttackPower = attack;
            Speed = speed;
            CriticalHitChance = crit;
        }
    }
}
