using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete
{
    class Dice
    {
        int sides;

        public Dice(int sides)
        {
            this.sides = sides; 
        }

        public int Roll() 
        {
            Random random = new Random();
            int sideRolls = random.Next(sides) + 1;
            return sideRolls;
        }
    }
}
