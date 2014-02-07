using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projektarbete.Data
{
    public class Item
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Health { get; set; }

        public int AttackPower { get; set; }

        public int Speed { get; set; }

        public int CriticalHitChance { get; set; }

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
