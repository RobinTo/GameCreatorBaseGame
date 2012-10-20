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
            gameObject.xVelocity = MathHelper.Clamp(gameObject.xVelocity, -gameObject.maxXVelocity, gameObject.maxXVelocity);
            gameObject.yVelocity = MathHelper.Clamp(gameObject.yVelocity, -gameObject.maxYVelocity, gameObject.maxYVelocity);
            // Move position by velocity and limit to on-screen.
            gameObject.yPosition = MathHelper.Clamp(gameObject.yPosition + gameObject.yVelocity, 0, GameConstants.ScreenHeight - gameObject.texture.Height);
            gameObject.xPosition = MathHelper.Clamp(gameObject.xPosition + gameObject.xVelocity, 0, GameConstants.ScreenWidth - gameObject.texture.Width);
            // Really is no gravity.
        }
    }
}
