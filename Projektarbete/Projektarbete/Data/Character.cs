using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete.Data
{
    class Character
    {
        private Dictionary<Stat, int> stats = new Dictionary<Stat, int>();

        public string Name { get; private set; }
        public int CurrentHealth { get; private set; }
        public bool Dead { get; private set; }

        public virtual int Health
        {
            get
            {
                return stats.ContainsKey(Stat.Health) ? stats[Stat.Health] : 0;
            }
            private set
            {
                stats[Stat.Health] = value;
            }
        }
        public virtual int AttackPower 
        {
            get
            {
                return stats.ContainsKey(Stat.AttackPower) ? stats[Stat.AttackPower] : 0;
            }

            private set
            {
                stats[Stat.Health] = value;
            }
        }
        public virtual int Speed 
        {
            get
            {
                return stats.ContainsKey(Stat.Speed) ? stats[Stat.Speed] : 0; ;
            }
            private set
            {
                stats[Stat.Speed] = value;
            }
        }
        public virtual int CriticalHitChance 
        {
            get
            {
                return stats.ContainsKey(Stat.CriticalHitChance) ? stats[Stat.CriticalHitChance] : 0;
            }
            private set
            {
                stats[Stat.CriticalHitChance] = value;
            }
        }

        public Character(string name, int health, int attack, int speed, int crit)
        {
            Name = name;
            Health = health;
            AttackPower = attack;
            Speed = speed;
            CriticalHitChance = crit;
        }
        
        public void Hit(Character target)
        {
            Dice dice = new Dice(10);

            int power = dice.Roll() * AttackPower;

            double roll = dice.Roll();
            if (roll <= CriticalHitChance)
            {
                if (roll == 1)
                    roll = 1.5;

                power = (int)(power + AttackPower * roll);

            }

            if (dice.Roll() <= Speed)
                target.Hurt(power);
        }

        public void Hurt(int power)
        {
            CurrentHealth = CurrentHealth - power;

            if (CurrentHealth <=0)
                Die();
        }

        public void Die()
        {
            Dead = true;
        }

    }
}
