using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    class UpdateComponent
    {
        public EventHandler eventHandler;

        public UpdateComponent(EventHandler eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        public virtual void Update(GameObject gameObject, GameTime gameTime)
        {

        }
    }
}
