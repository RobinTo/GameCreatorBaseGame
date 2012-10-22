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
                    if (events[i].ID == 0)
                        xVelocity += 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else if (events[i].ID == 1)
                        xVelocity -= 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else if (events[i].ID == 2)
                        xVelocity = 0;
                    else if (events[i].ID == 3)
                        yVelocity += 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else if (events[i].ID == 4)
                        yVelocity -= 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    else if (events[i].ID == 5)
                        yVelocity = 0;
                    else if (events[i].ID == 10)
                    {
                        if (xVelocity > 0)
                            xVelocity = -10;
                        else
                            xVelocity = 10;
                    }
                }
            }
            // -----------------------
            

            xVelocity = MathHelper.Clamp(xVelocity, -maxXVelocity, maxXVelocity);
            yVelocity = MathHelper.Clamp(yVelocity, -maxYVelocity, maxYVelocity);
            // Move position by velocity and limit to on-screen.
            gameObject.yPosition = MathHelper.Clamp(gameObject.yPosition + yVelocity, 0, GameConstants.ScreenHeight - gameObject.height);
            gameObject.xPosition = MathHelper.Clamp(gameObject.xPosition + xVelocity, 0, GameConstants.ScreenWidth - gameObject.width);
            // Really is no gravity.
        }
    }
}
