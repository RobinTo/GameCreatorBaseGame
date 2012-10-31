// This component is used by explosion, it checks whether tiles diagonally and horizontally are "solid"
// and expands into there if not by creating a duplicate object.

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    class ExpandComponent : UpdateComponent
    {
        Map_2DTile map;
        int expandLimit;
        bool hasExpanded = false;

        public ExpandComponent(EventHandler eventHandler, Map_2DTile map, int expandLimit)
            : base(eventHandler)
        {
            this.map = map;
            this.expandLimit = expandLimit;
        }

        public bool CanMoveToTile(int x, int y)
        {
            if (x >= 0 && x < GameConstants.MapWidth && y >= 0 && y < GameConstants.MapHeight)
            {
                if (map.Map[x, y] != 0)
                    return false;
                else
                    return true;
            }
            return false;
        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            if (!hasExpanded)
            {
                int positionX = (int)Math.Round((double)gameObject.xPosition / GameConstants.TileWidth, 0);
                int positionY = (int)Math.Round((double)gameObject.yPosition / GameConstants.TileHeight, 0);
                bool moveLeft = true;
                bool moveRight = true;
                bool moveUp = true;
                bool moveDown = true;
                for (int i = 1; i <= expandLimit; i++)
                {
                    if (moveRight && CanMoveToTile(positionX + i, positionY))
                    {
                        eventHandler.QueueEvent(new SpawnEvent("explosionExpansion", (positionX * GameConstants.TileWidth) + (i * GameConstants.TileWidth), positionY * GameConstants.TileHeight));
                    }
                    else
                    {
                        moveRight = false;
                    }
                    if (moveLeft && CanMoveToTile(positionX - i, positionY))
                    {
                        eventHandler.QueueEvent(new SpawnEvent("explosionExpansion", (positionX * GameConstants.TileWidth) - (i * GameConstants.TileWidth), positionY * GameConstants.TileHeight));
                    }
                    else
                    {
                        moveLeft = false;
                    }
                    if (moveDown && CanMoveToTile(positionX, positionY + i))
                    {
                        eventHandler.QueueEvent(new SpawnEvent("explosionExpansion", (positionX * GameConstants.TileWidth), (positionY * GameConstants.TileHeight) + (i * GameConstants.TileHeight)));
                    }
                    else
                    {
                        moveDown = false;
                    }
                    if (moveUp && CanMoveToTile(positionX, positionY - i))
                    {
                        eventHandler.QueueEvent(new SpawnEvent("explosionExpansion", (positionX * GameConstants.TileWidth), (positionY * GameConstants.TileHeight) - (i * GameConstants.TileHeight)));
                    }
                    else
                    {
                        moveUp = false;
                    }
                }
                hasExpanded = true;
            }
        }
    }
}
