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
                switch (events[i].ID)
                {
                    case Events.SpawnPlayer:
                        GameObject player = new GameObject();
                        player.AddDrawComponent(new Graphics2DImageComponent(graphicsHandler.getTexture("player")));             // Basic graphics component with no animation.
                        player.AddUpdateComponent(new SnapToTileMovementComponent(eventHandler, map, 32, 32));                  // Sets starting position of object and enables it to move in tiles based on events from input component.
                        player.AddUpdateComponent(new KeyboardInputComponent(eventHandler));                                    // Takes input from local keyboard.
                        AttachID(player);                                                                                       // Set ID counter
                        gameObjects.Add(player);                                                                                // Add to game objects, to run in loops.
                        break;
                    case Events.SpawnBomb:
                        GameObject newBomb = new GameObject();
                        for (int p = 0; p < gameObjects.Count; p++)
                        {
                            if (gameObjects[p].ID == events[i].ActOnID)
                            {
                                newBomb.xPosition = gameObjects[p].xPosition;
                                newBomb.yPosition = gameObjects[p].yPosition;
                            }
                        }
                        newBomb.AddDrawComponent(new Graphics2DImageComponent(graphicsHandler.getTexture("bomb")));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
