// Title
// 2D Top-Down Physics

// Description
// Provides a game object with elementary 2D physics.

// Group
// Physics

using System;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    class PhysicsComponent : UpdateComponent
    {
        public override void  Update(GameObject gameObject, GameTime gameTime)
        {
            // I do now know what phyisics there are in a 2D top down game? :-]
            // Adding some test cases just for the sake of showing how a component could work.

            gameObject.yVelocity += 1.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            gameObject.yPosition += gameObject.yVelocity;
            if (gameObject.yPosition + gameObject.texture.Height > GameConstants.ScreenHeight)
            {
                gameObject.yPosition = GameConstants.ScreenHeight - gameObject.texture.Height;
            }
        }
    }
}
