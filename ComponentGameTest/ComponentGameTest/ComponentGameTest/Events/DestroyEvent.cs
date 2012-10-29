using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComponentGameTest
{
    class DestroyEvent : GameEvent
    {
        int idToDestroy;

        public int getID
        {
            get
            {
                return idToDestroy;
            }
        }

        public DestroyEvent(int idToDestroy)
            : base(Events.DestroyObject)
        {
            this.idToDestroy = idToDestroy;
        }
    }
}
