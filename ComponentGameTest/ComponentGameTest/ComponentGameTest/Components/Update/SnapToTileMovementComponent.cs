﻿// Title
// 2D Top-Down Physics

// Description
// Provides a game object with elementary 2D physics.

// Group
// Physics

// Editable variables
// moveTime : float

// Notes
// Uses tile sizes from GameConstants, asumes player is size of tile.

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace ComponentGameTest
{
    enum Moves
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3,
        None
    }

    class SnapToTileMovementComponent : UpdateComponent
    {
        const float moveTime = 0.25f;
        float moveTimer = 0;
        int targetPosX = -1;
        int targetPosY = -1;
        Moves moveDirection;
        Map_2DTile m;

        public SnapToTileMovementComponent(EventHandler eventHandler, Map_2DTile m, int StartingPosX, int StartingPosY)
            : base(eventHandler)
        {
            this.m = m;
            targetPosX = StartingPosX;
            targetPosY = StartingPosY;
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
            if (moveTimer <= 0)
            {
                gameObject.xPosition = targetPosX;
                gameObject.yPosition = targetPosY;
                List<GameEvent> events = eventHandler.Events;
                for (int i = 0; i < events.Count; i++)
                {
                    if (events[i].ActOnID == gameObject.ID)
                    {
                        int positionX = (int)Math.Round(gameObject.xPosition / GameConstants.TileWidth, 0);
                        int positionY = (int)Math.Round(gameObject.yPosition / GameConstants.TileHeight, 0);
                        if (events[i].ID == Events.MoveRight)
                        {
                            if (CanMoveToTile(positionX + 1, positionY))
                            {
                                moveDirection = Moves.Right;
                                targetPosX += GameConstants.TileWidth;
                                moveTimer = moveTime;
                            }
                        }
                        else if (events[i].ID == Events.MoveLeft)
                        {
                            if (CanMoveToTile(positionX - 1, positionY))
                            {
                                moveDirection = Moves.Left;
                                targetPosX -= GameConstants.TileWidth;
                                moveTimer = moveTime;
                            }
                        }
                        else if (events[i].ID == Events.MoveDown)
                        {
                            if (CanMoveToTile(positionX, positionY + 1))
                            {
                                moveDirection = Moves.Down;
                                targetPosY += GameConstants.TileHeight;
                                moveTimer = moveTime;
                            }
                        }
                        else if (events[i].ID == Events.MoveUp)
                        {
                            if (CanMoveToTile(positionX, positionY - 1))
                            {
                                moveDirection = Moves.Up;
                                targetPosY -= GameConstants.TileHeight;
                                moveTimer = moveTime;
                            }
                        }
                    }
                }
            }
            else if (moveDirection != Moves.None)
            {
                switch (moveDirection)
                {
                    case Moves.Down:
                        gameObject.yPosition += (float)((GameConstants.TileHeight / moveTime) * gameTime.ElapsedGameTime.TotalSeconds);
                        if (Math.Round(gameObject.yPosition, 0) == targetPosY)
                        {
                            gameObject.yPosition = targetPosY;
                            moveDirection = Moves.None;
                        }
                        break;
                    case Moves.Up:
                        gameObject.yPosition -= (float)((GameConstants.TileHeight / moveTime) * gameTime.ElapsedGameTime.TotalSeconds);
                        if (Math.Round(gameObject.yPosition, 0) == targetPosY)
                        {
                            gameObject.yPosition = targetPosY;
                            moveDirection = Moves.None;
                        }
                        break;
                    case Moves.Left:
                        gameObject.xPosition -= (float)((GameConstants.TileHeight / moveTime) * gameTime.ElapsedGameTime.TotalSeconds);
                        if (Math.Round(gameObject.xPosition, 0) == targetPosX)
                        {
                            gameObject.xPosition = (float)Math.Round(gameObject.xPosition, 0);
                            moveDirection = Moves.None;
                        }
                        break;
                    case Moves.Right:
                        gameObject.xPosition += (float)((GameConstants.TileHeight / moveTime) * gameTime.ElapsedGameTime.TotalSeconds);
                        break;
                    default:
                        break;
                }
            }
            // -----------------------
        }
    }
}