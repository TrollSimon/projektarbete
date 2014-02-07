using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete
{
    class Choice
    {
        string description;

        public string Description
        {
            get
            {
                return description;
            }
        }

        public Choice(string description)
        {
            this.description = description;

        }

        int eventID;
        public int EventID
        {
            get
              {
                  return eventID;
              }
        }

        public Choice(int eventID)
        {
            this.eventID = eventID;
        }
    }
}
