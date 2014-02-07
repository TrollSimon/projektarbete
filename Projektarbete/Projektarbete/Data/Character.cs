using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete.Data
{
    class Character
    {
        public string Name { get; private set; }
        public int CurrentHealth { get; private set; }
        public bool Dead { get; private set; }

        public virtual int Health { get; private set; }
        public virtual int AttackPower { get; private set; }
        public virtual int Speed { get; private set; }
        public virtual int CriticalHitChance { get; private set; }

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
