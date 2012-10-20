using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentGameTest
{
    class EventHandler
    {
        List<GameEvent> events = new List<GameEvent>();

        List<GameEvent> queuedEvents = new List<GameEvent>();

        public List<GameEvent> Events
        {
            get
            {
                return events;
            }
        }

        public void NewRound()
        {
            events.Clear();
            for (int i = 0; i < queuedEvents.Count; i++ )
                events.Add(queuedEvents[i]);
            queuedEvents.Clear();
        }

        public void QueueEvent(GameEvent e)
        {
            queuedEvents.Add(e);
        }
    }
}
