using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    class TimerComponent : UpdateComponent
    {
        float time;
        GameEvent eventToCreate;

        public TimerComponent(EventHandler eventHandler, float time, GameEvent eventToCreate)
            : base(eventHandler)
        {
            this.time = time;
            this.eventToCreate = eventToCreate;
        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            time -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time <= 0)
                eventHandler.QueueEvent(eventToCreate);
        }
    }
}
