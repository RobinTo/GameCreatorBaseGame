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
    class KeyboardInputComponent : UpdateComponent
    {
        KeyboardState oldK = new KeyboardState();
        KeyboardState newK = new KeyboardState();

        public KeyboardInputComponent(EventHandler eventHandler)
            : base(eventHandler)
        {
        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            newK = Keyboard.GetState();

            foreach (Keys k in newK.GetPressedKeys())
            {
                eventHandler.QueueEvent(new InputEvent(k, gameObject.ID));
            }

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
