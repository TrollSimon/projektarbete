using Projektarbete.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbete
{
    static class Game
    {
        private const int startEventID = 1;
        private const int playerCharacterID = 1;

       static private Player _player = new Player(DataStore.GetCharacter(playerCharacterID));
       static private Event _event = DataStore.GetEvent(startEventID);

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

        static public void ChangeEvent(int eventId)
        {
            Event ev = DataStore.GetEvent(eventId);
            if (ev != null)
                _event = ev;

        }
    }
}
