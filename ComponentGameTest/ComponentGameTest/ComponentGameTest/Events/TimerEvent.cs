using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentGameTest
{
    class TimerEvent : GameEvent
    {
        int timerID;

        public int TimerID
        {
            get
            {
                return timerID;
            }
        }

        public TimerEvent(int timerID)
            : base(Events.Timer)
        {
            this.timerID = timerID;
        }
    }
}
