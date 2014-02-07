using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete.Data
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

        int eventID;
        public int EventID
        {
            get
              {
                  return eventID;
              }
        }

        public Choice(string description, int eventID)
        {
            this.description = description;
            this.eventID = eventID;
        }
    }
}
