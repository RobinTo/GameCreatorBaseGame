// Spawns and destroys objects based on events

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ComponentGameTest
{
    class ObjectSpawnController
    {
        EventHandler eventHandler;
        List<GameObject> gameObjects = new List<GameObject>();
        GraphicsHandler2D graphicsHandler;
        Map_2DTile map;

        int IDCounter = 0;
        private void AttachID(GameObject gameObject)
        {
            gameObject.ID = IDCounter;
            IDCounter++;
        }

        public ObjectSpawnController(EventHandler eventHandler, List<GameObject> gameObjects, GraphicsHandler2D graphicsHandler, Map_2DTile map)
        {
            this.eventHandler = eventHandler;
            this.gameObjects = gameObjects;
            this.graphicsHandler = graphicsHandler;
            this.map = map;
        }

        public void Update(GameTime gameTime)
        {
            List<GameEvent> events = eventHandler.Events;
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].ID == Events.SpawnObject)
                {
                    switch ((events[i] as SpawnEvent).ObjectName)
                    {
                        case "player":
                            GameObject newPlayer = new GameObject();
                            AttachID(newPlayer);
                            newPlayer.AddUpdateComponent(new KeyboardInputComponent(eventHandler));
                            newPlayer.AddDrawComponent(new Graphics2DImageComponent(graphicsHandler.getTexture("player")));
                            newPlayer.AddUpdateComponent(new SnapToTileMovementComponent(eventHandler, map, gameObjects, GameConstants.TileWidth, GameConstants.TileHeight));
                            newPlayer.AddUpdateComponent(new SpawnObjectComponent(eventHandler, "bomb", Keys.Space, 2.5f));
                            gameObjects.Add(newPlayer);
                            break;
                        case "bomb":
                            GameObject newBomb = new GameObject();
                            AttachID(newBomb);
                            if ((events[i] as SpawnEvent).hasPosition)
                            {
                                newBomb.xPosition = (float)(Math.Round((events[i] as SpawnEvent).xPos / GameConstants.TileWidth, 0) * GameConstants.TileWidth);
                                newBomb.yPosition = (float)(Math.Round((events[i] as SpawnEvent).yPos / GameConstants.TileHeight, 0) * GameConstants.TileHeight);
                            }
                            newBomb.AddDrawComponent(new Graphics2DImageComponent(graphicsHandler.getTexture("bomb")));
                            newBomb.AddUpdateComponent(new TimerComponent(eventHandler, 2.0f, new DestroyEvent(newBomb.ID)));
                            newBomb.AddUpdateComponent(new TimerComponent(eventHandler, 2.0f, new SpawnEvent("explosionCenter", newBomb.xPosition, newBomb.yPosition)));
                            gameObjects.Add(newBomb);
                            break;
                        case "explosionCenter":
                            GameObject explosion = new GameObject();
                            AttachID(explosion);
                            explosion.isSolid = false;
                            if ((events[i] as SpawnEvent).hasPosition)
                            {
                                explosion.xPosition = (float)(Math.Round((events[i] as SpawnEvent).xPos / GameConstants.TileWidth, 0) * GameConstants.TileWidth);
                                explosion.yPosition = (float)(Math.Round((events[i] as SpawnEvent).yPos / GameConstants.TileHeight, 0) * GameConstants.TileHeight);
                            }
                            explosion.AddDrawComponent(new Graphics2DImageComponent(graphicsHandler.getTexture("explosion")));
                            explosion.AddUpdateComponent(new ExpandComponent(eventHandler, map, 3));
                            explosion.AddUpdateComponent(new TimerComponent(eventHandler, 0.26f, new DestroyEvent(explosion.ID)));
                            gameObjects.Add(explosion);
                            break;
                        case "explosionExpansion": // Need one without the expandcomponent to keep it from expanding forevet
                            GameObject explosionExpansion = new GameObject();
                            AttachID(explosionExpansion);
                            explosionExpansion.isSolid = false;
                            if ((events[i] as SpawnEvent).hasPosition)
                            {
                                explosionExpansion.xPosition = (float)(Math.Round((events[i] as SpawnEvent).xPos / GameConstants.TileWidth, 0) * GameConstants.TileWidth);
                                explosionExpansion.yPosition = (float)(Math.Round((events[i] as SpawnEvent).yPos / GameConstants.TileHeight, 0) * GameConstants.TileHeight);
                            }
                            explosionExpansion.AddDrawComponent(new Graphics2DImageComponent(graphicsHandler.getTexture("explosion")));
                            explosionExpansion.AddUpdateComponent(new TimerComponent(eventHandler, 0.25f, new DestroyEvent(explosionExpansion.ID)));
                            gameObjects.Add(explosionExpansion);
                            break;
                        // Insert code for objects here.
                        default:
                            break;
                    }
                }
                else if (events[i].ID == Events.DestroyObject)
                {
                    List<GameObject> objectsToRemove = new List<GameObject>();
                    for (int t = 0; t < gameObjects.Count; t++)
                    {
                        if ((events[i] as DestroyEvent).getID == gameObjects[t].ID)
                        {
                            objectsToRemove.Add(gameObjects[t]);
                        }
                    }
                    foreach (GameObject go in objectsToRemove)
                    {
                        gameObjects.Remove(go);
                    }
                }
            }
        }
    }
}
