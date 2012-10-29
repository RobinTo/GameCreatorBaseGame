﻿// Title
// Collides With Map

// Description
// Makes a game collide with the map without tiles.

// Group
// Physics

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    class Map_2DTileCollisionComponent : UpdateComponent
    {
        Map_2DTile m;

        public Map_2DTileCollisionComponent(EventHandler eventHandler, Map_2DTile m)
            : base(eventHandler)
        {
            this.m = m;
        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            CollidesWithTile(gameObject);
        }

        public void CollidesWithTile(GameObject gameObject)
        {
            Rectangle startingBounds = new Rectangle((int)gameObject.xPosition, (int)gameObject.yPosition, gameObject.width, gameObject.height);
            int leftTile = (int)Math.Floor((float)startingBounds.Left / GameConstants.TileWidth);
            int rightTile = (int)Math.Ceiling(((float)startingBounds.Right / GameConstants.TileWidth)) - 1;
            int topTile = (int)Math.Floor((float)startingBounds.Top / GameConstants.TileHeight);
            int bottomTile = (int)Math.Ceiling(((float)startingBounds.Bottom / GameConstants.TileHeight)) - 1;

            for (int y = topTile; y <= bottomTile; ++y)
            {
                for (int x = leftTile; x <= rightTile; ++x)
                {
                    Rectangle objectBounds = new Rectangle((int)gameObject.xPosition, (int)gameObject.yPosition, gameObject.width, gameObject.height);
                    Rectangle tileBounds = new Rectangle(x * GameConstants.TileWidth, y * GameConstants.TileHeight, GameConstants.TileWidth, GameConstants.TileHeight);
                    if (m.Map[x,y] != 0 && objectBounds.Intersects(tileBounds))                       // Change to different tiles, not just 0 to be non collideable.
                    {
                        Vector2 depth = RectangleExtensions.GetIntersectionDepth(objectBounds, tileBounds);
                        if (depth != Vector2.Zero)
                        {
                            float absDepthX = Math.Abs(depth.X);
                            float absDepthY = Math.Abs(depth.Y);

                            if (absDepthY < absDepthX)
                            {
                                gameObject.yPosition = gameObject.yPosition + depth.Y;
                            }
                            else
                            {
                                gameObject.xPosition = gameObject.xPosition + depth.X;
                            }

                            gameObject.xPosition = (float)Math.Round(gameObject.xPosition);
                            gameObject.yPosition = (float)Math.Round(gameObject.yPosition);
                        }
                    }
                }
            }
        }
    }
}
