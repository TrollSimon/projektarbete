using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete
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
                return stats[Stat.Health];
            }
            private set
            {
                stats[Stat.Health] = value;
            }
        }
        public virtual int AttakPower 
        {
            get
            {
                return stats[Stat.AttackPower];
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
                return stats[Stat.Speed];
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
                return stats[Stat.CriticalHitChance];
            }
            private set
            {
                stats[Stat.CriticalHitChance] = value;
            }
        }

        public void Hit(Character target)
        {
            Dice dice = new Dice();

            int power = dice.Roll() * AttakPower;

            double roll = dice.Roll();
            if (roll <= CriticalHitChance)
            {
                if (roll == 1)
                    roll = 1.5;

                power = (int)(power + AttakPower * roll);

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
