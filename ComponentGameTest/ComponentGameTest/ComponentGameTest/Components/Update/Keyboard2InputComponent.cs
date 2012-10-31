// Title
// Keyboard Input

// Descripion
// Provides input component for normal keyboards.

// Group
// Input

// Notes
// Which keys send which inputs be added dynamically perhaps?

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ComponentGameTest
{
    class Keyboard2InputComponent : UpdateComponent
    {
        KeyboardState oldK = new KeyboardState();
        KeyboardState newK = new KeyboardState();

        public Keyboard2InputComponent(EventHandler eventHandler)
            : base(eventHandler)
        {
        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            newK = Keyboard.GetState();

            if (IsKeyDown(Keys.Left))
                eventHandler.QueueEvent(new InputEvent(Keys.A, gameObject.ID));
            if (IsKeyDown(Keys.Right))
                eventHandler.QueueEvent(new InputEvent(Keys.D, gameObject.ID));
            if (IsKeyDown(Keys.Up))
                eventHandler.QueueEvent(new InputEvent(Keys.W, gameObject.ID));
            if (IsKeyDown(Keys.Down))
                eventHandler.QueueEvent(new InputEvent(Keys.S, gameObject.ID));
            if (IsKeyDown(Keys.Enter))
                eventHandler.QueueEvent(new InputEvent(Keys.Space, gameObject.ID));

            oldK = newK;
        }

        // Is a given key down.
        public bool IsKeyDown(Keys k)
        {
            return newK.IsKeyDown(k);
        }

        // If we just want a new keypress. I.e. IsKeyDown(Keys.I) for 
        // inventory would open and close it 60 times per second, while this would just
        // register one click, when it is pressed for the first time.
        public bool IsNewKeyDown(Keys k)
        {
            return (newK.IsKeyDown(k) && !oldK.IsKeyDown(k));
        }
    }
}
