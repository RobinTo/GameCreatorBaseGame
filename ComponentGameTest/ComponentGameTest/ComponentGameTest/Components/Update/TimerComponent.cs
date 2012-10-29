using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    class TimerComponent : UpdateComponent
    {
        float time;
        Events eventToCreate;

        public TimerComponent(EventHandler eventHandler, float time, Events eventToCreate)
            : base(eventHandler)
        {
            this.time = time;
            this.eventToCreate = eventToCreate;
        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            time -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time <= 0)
                eventHandler.QueueEvent(new GameEvent(eventToCreate, gameObject.ID));
        }
    }
}
