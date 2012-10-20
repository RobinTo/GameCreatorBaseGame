// Title
// Bounding box collision

// Description
// Checks collision between the squares formed by gameObjects xPosition, yPosition, textureWidth, textureHeight.

// Notes
// Should probably rather create some event which would be handled by the physics component.

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ComponentGameTest
{
    class CollisionComponent : UpdateComponent
    {
        List<GameObject> gameObjects;

        public CollisionComponent(List<GameObject> gameObjects, EventHandler eventHandler)
            : base(eventHandler)
        {
            this.gameObjects = gameObjects;
        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if(gameObjects[i] != gameObject)
                if(new Rectangle((int)gameObject.xPosition, (int)gameObject.yPosition, gameObject.texture.Width, gameObject.texture.Height).Intersects
                    (new Rectangle((int)gameObjects[i].xPosition, (int)gameObjects[i].yPosition, gameObjects[i].texture.Width, gameObjects[i].texture.Height)))
                {
                    // Collision.
                    gameObject.xPosition += 5.0f;
                }   
            }
        }
    }
}
