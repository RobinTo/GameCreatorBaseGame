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
    class SnapToTileMovementComponent : UpdateComponent
    {
        const float moveTime = 0.25f;
        float moveTimer = moveTime;
        Map_2DTile m;

        public SnapToTileMovementComponent(EventHandler eventHandler, Map_2DTile m)
            : base(eventHandler)
        {
            this.m = m;
        }

        public bool CanMoveToTile(int x, int y)
        {
            if (x >= 0 && x < GameConstants.MapWidth && y >= 0 && y < GameConstants.MapHeight)
            {
                if (m.Map[x, y] != 0)
                    return false;
                else
                    return true;
            }
            return false;
        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            moveTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            // Event handling
            List<GameEvent> events = eventHandler.Events;
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].ActOnID == gameObject.ID)
                {
                    int positionX = (int)Math.Round(gameObject.xPosition / GameConstants.TileWidth, 0);
                    int positionY = (int)Math.Round(gameObject.yPosition / GameConstants.TileHeight, 0);
                    if (events[i].ID == 0)
                    {
                        if (CanMoveToTile(positionX + 1, positionY) && moveTimer <= 0)
                        {
                            gameObject.xPosition += GameConstants.TileWidth;
                            moveTimer = moveTime;
                        }
                    }
                    else if (events[i].ID == 1)
                    {
                        if (CanMoveToTile(positionX - 1, positionY) && moveTimer <= 0)
                        {
                            gameObject.xPosition -= GameConstants.TileWidth;
                            moveTimer = moveTime;
                        }
                    }
                    else if (events[i].ID == 3)
                    {
                        if (CanMoveToTile(positionX, positionY + 1) && moveTimer <= 0)
                        {
                            gameObject.yPosition += GameConstants.TileHeight;
                            moveTimer = moveTime;
                        }
                    }
                    else if (events[i].ID == 4)
                    {
                        if (CanMoveToTile(positionX, positionY - 1) && moveTimer <= 0)
                        {
                            gameObject.yPosition -= GameConstants.TileHeight;
                            moveTimer = moveTime;
                        }
                    }
                }
            }
            // -----------------------
        }
    }
}
