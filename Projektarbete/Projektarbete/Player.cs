using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete
{
    class Player : Character
    {
        public Item Weapon { get; set; }
        public List<Item> Inventory { get; private set; }
        public int BaseHealth
        {
            get
            {
                return base.Health;
            }

        }

        public int BaseAttakPower
        {
            get
            {
                return base.AttakPower;

            }

        }

        public int BaseSpeed
        {
            get
            {
                return base.Speed;

            }

        }

        public int BaseCriticalHitChance
        {
            get
            {
                return base.CriticalHitChance;

            }

        }

        public override int Health
        {
        
            get
            {
                return Weapon.Health + base.Health;
            }
        }
        public override int AttakPower 
        {
            get
            {
                return Weapon.AttakPower + base.AttakPower;
            }
        }
        public override int Speed 
        {
            get
            {
                return Weapon.Speed + base.Speed;
            }
        }
        public override int CriticalHitChance
        {
            get
            {
                return Weapon.CriticalHitChance + base.CriticalHitChance;
            }
        }


    }
}
