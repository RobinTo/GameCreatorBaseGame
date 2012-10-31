using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    class CollidesWithObjectComponent : UpdateComponent
    {

        public CollidesWithObjectComponent(EventHandler eventHandler)
            : base(eventHandler)
        {

        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            List<GameEvent> events = eventHandler.Events;
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].ID == Events.Collision)
                {
                    if ((events[i] as CollisionEvent).object1 == gameObject)
                    {
                        if ((events[i] as CollisionEvent).object2.type == "explosionCenter" || (events[i] as CollisionEvent).object2.type == "explosionExpansion")
                            eventHandler.QueueEvent(new DestroyEvent(gameObject.ID));
                        // Do Something
                    }
                    else if ((events[i] as CollisionEvent).object2 == gameObject)
                    {
                        if ((events[i] as CollisionEvent).object1.type == "explosionCenter" || (events[i] as CollisionEvent).object1.type == "explosionExpansion")
                            eventHandler.QueueEvent(new DestroyEvent(gameObject.ID));
                        // Do something
                    }
                }
            }
        }

    }
}
