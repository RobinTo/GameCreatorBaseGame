// Title
// 2D Top-Down Physics

// Description
// Provides a game object with elementary 2D physics.

// Group
// Physics

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    class PhysicsComponent : UpdateComponent
    {
        float xVelocity = 0;
        float yVelocity = 0;
        float maxXVelocity = 5;
        float maxYVelocity = 5;

        public PhysicsComponent(EventHandler eventHandler)
            : base(eventHandler)
        {
        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            // Event handling
            List<GameEvent> events = eventHandler.Events;
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].ActOnID == gameObject.ID)
                {
                    if (events[i].ID == Events.MoveRight)
                        xVelocity += 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else if (events[i].ID == Events.MoveLeft)
                        xVelocity -= 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else if (events[i].ID == Events.MoveDown)
                        yVelocity += 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else if (events[i].ID == Events.MoveUp)
                        yVelocity -= 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
            }
            // -----------------------
            

            xVelocity = MathHelper.Clamp(xVelocity, -maxXVelocity, maxXVelocity);
            yVelocity = MathHelper.Clamp(yVelocity, -maxYVelocity, maxYVelocity);
            // Move position by velocity and limit to on-screen.
            gameObject.yPosition = MathHelper.Clamp(gameObject.yPosition + yVelocity, 0, GameConstants.ScreenHeight - gameObject.height);
            gameObject.xPosition = MathHelper.Clamp(gameObject.xPosition + xVelocity, 0, GameConstants.ScreenWidth - gameObject.width);
            // The mind is its own place, and can make heaven out of hell, or hell out of heaven.
        }
    }
}
