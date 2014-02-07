using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete
{
    static class Game
    {
       static private Player _player = new Player();
       static private Event _event = new Event();

       static public Player Player 
        {
            get
            {
                return _player;
            }
        }
       static public Event Event
        {
            get
            {
                return _event;
            }
        }

        static public void ChangeEvent(Event newEvent)
        {
            if (newEvent != null)
                _event = newEvent;

        }
    }
}
