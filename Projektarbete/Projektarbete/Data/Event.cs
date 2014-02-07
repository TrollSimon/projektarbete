using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete.Data
{
    class Event
    {
        private List<Choice> choices;
        public string Description { get; private set; }

        public Event(string description, List<Choice> choices)
        {
            Description = description;
            this.choices = choices;
        }

        public void MakeChoice(int choice)
        {
            if (choice < choices.Count && choice > -1)
                Game.ChangeEvent(choices.ElementAt(choice).EventID);
        }

        public string GetChoice(int choice)
        {
            if (choice < choices.Count && choice > -1)
                return choices.ElementAt(choice).Description;
            else
                return "";
        }
    }
}
