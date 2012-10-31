using System;
using System.Collections.Generic;

namespace ComponentGameTest
{
    class CollisionEvent : GameEvent
    {
        public GameObject object1;
        public GameObject object2;

        public CollisionEvent(GameObject object1, GameObject object2)
            : base(Events.Collision)
        {
            this.object1 = object1;
            this.object2 = object2;
        }
    }
}
