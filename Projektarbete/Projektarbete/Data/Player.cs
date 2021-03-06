﻿using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete.Data
{
    class Player : Character
    {
        public Item Weapon { get; private set; }
        public List<Item> Inventory { get; private set; }

        public int BaseHealth
        {
            get
            {
                return base.Health;
            }
        }
        public int BaseAttackPower
        {
            get
            {
                return base.AttackPower;
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
                if (Weapon == null)
                    return base.Health;

                return Weapon.Health + base.Health;
            }
        }
        public override int AttackPower 
        {
            get
            {
                if (Weapon == null)
                    return base.AttackPower;

                return Weapon.AttackPower + base.AttackPower;
            }
        }
        public override int Speed 
        {
            get
            {
                if (Weapon == null)
                    return base.Speed;

                return Weapon.Speed + base.Speed;
            }
        }
        public override int CriticalHitChance
        {
            get
            {
                if (Weapon == null)
                    return base.CriticalHitChance;

                return Weapon.CriticalHitChance + base.CriticalHitChance;
            }
        }

        public Player(Character character)
            : this(character.Name, character.Health, character.AttackPower, character.Speed, character.CriticalHitChance) { }

        public Player(string name, int health, int attack, int speed, int crit)
            : base(name, health, attack, speed, crit)
        {
            Inventory = new List<Item>();
        }

    }
}
