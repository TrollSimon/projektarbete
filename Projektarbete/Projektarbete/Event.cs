using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete
{
    class Event
    {
        private Dictionary<string, Event> choices;

        public int ID { get; private set; }
        public string Description { get; private set; }

        public void MakeChoice(int choice)
        {
            if (choice < choices.Count && choice > -1)
                Game.ChangeEvent(choices.Values.ElementAt(choice));
        }

        public string GetChoice(int choice)
        {
            if (choice < choices.Count && choice > -1)
                return choices.Keys.ElementAt(choice);
            else
                return "";
        }
    }
}
