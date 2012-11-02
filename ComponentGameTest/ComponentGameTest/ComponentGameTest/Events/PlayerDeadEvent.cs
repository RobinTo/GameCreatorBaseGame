using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentGameTest
{
    class PlayerDeadEvent : GameEvent
    {

        public PlayerDeadEvent()
            : base(Events.PlayerDead)
        {
            
        }

    }
}
