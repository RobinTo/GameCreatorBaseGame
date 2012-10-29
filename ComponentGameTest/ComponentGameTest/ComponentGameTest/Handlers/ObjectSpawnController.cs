// Spawns objects based on events
// Dynamic code to be added

// if event.ID = some spawn event
// add new object defined in game editor to gameObjects

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

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
                            newPlayer.AddUpdateComponent(new KeyboardInputComponent(eventHandler));
                            newPlayer.AddDrawComponent(new Graphics2DImageComponent(graphicsHandler.getTexture("player")));
                            newPlayer.AddUpdateComponent(new SnapToTileMovementComponent(eventHandler, map, GameConstants.TileWidth, GameConstants.TileHeight));
                            gameObjects.Add(newPlayer);
                            break;
                        // Insert code for objects here.
                        default:
                            break;
                    }
                }
            }
        }
    }
}
