using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    class DestroyComponent : UpdateComponent
    {

        public DestroyComponent(EventHandler eventHandler)
            : base(eventHandler)
        {

        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            List<GameEvent> events = eventHandler.Events;
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].ID == Events.DestroyObject)
                    gameObject.remove = true;
            }
        }
    }
}
