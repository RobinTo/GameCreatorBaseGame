// Title
// Keyboard Input

// Descripion
// Provides input component for normal keyboards.

// Group
// Input

// Notes
// We need to change this to support multiplayer.

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ComponentGameTest
{
    class KeyboardInputComponent : UpdateComponent
    {
        KeyboardState oldK = new KeyboardState();
        KeyboardState newK = new KeyboardState();

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            newK = Keyboard.GetState();

            if (IsKeyDown(Keys.D))
            {
                if (gameObject.xVelocity < 0)
                    gameObject.xVelocity = 0;
                gameObject.xVelocity += 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (IsKeyDown(Keys.A))
            {
                if (gameObject.xVelocity > 0)
                    gameObject.xVelocity = 0;
                gameObject.xVelocity -= 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                gameObject.xVelocity = 0;
            }

            if (IsKeyDown(Keys.S))
            {
                if (gameObject.yVelocity < 0)
                    gameObject.yVelocity = 0;
                gameObject.yVelocity += 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (IsKeyDown(Keys.W))
            {
                if (gameObject.yVelocity > 0)
                    gameObject.yVelocity = 0;
                gameObject.yVelocity -= 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                gameObject.yVelocity = 0;
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
