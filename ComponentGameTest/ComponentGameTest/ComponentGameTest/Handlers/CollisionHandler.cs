using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    class CollisionHandler
    {
        List<GameObject> gameObjects;
        EventHandler eventHandler;
        public CollisionHandler(EventHandler eventHandler, List<GameObject> gameObjects)
        {
            this.gameObjects = gameObjects;
            this.eventHandler = eventHandler;
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int t = 0; t < gameObjects.Count; t++)
                {
                    if (i != t)
                    {
                        int positionX1 = (int)Math.Round(gameObjects[i].xPosition / GameConstants.TileWidth, 0);
                        int positionY1 = (int)Math.Round(gameObjects[i].yPosition / GameConstants.TileHeight, 0);
                        int positionX2 = (int)Math.Round(gameObjects[t].xPosition / GameConstants.TileWidth, 0);
                        int positionY2 = (int)Math.Round(gameObjects[t].yPosition / GameConstants.TileHeight, 0);
                        if (positionX1 == positionX2 && positionY1 == positionY2)
                            eventHandler.QueueEvent(new CollisionEvent(gameObjects[i], gameObjects[t]));
                    }
                }
            }
        }
    }
}
