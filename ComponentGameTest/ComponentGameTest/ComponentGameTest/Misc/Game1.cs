using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ComponentGameTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<GameObject> gameObjects = new List<GameObject>();
        EventHandler eventHandler = new EventHandler();
        GraphicsHandler2D graphicsHandler = new GraphicsHandler2D();
        SoundHandler soundHandler = new SoundHandler();
        ObjectSpawnController objectSpawnController;                // Created in loadContent.
        CollisionHandler collisionHandler;

        Map_2DTile map;
        SpriteFont font;

        // FPS counter variables
        double fpsTimer = 1.0;
        int lastUpdate = 0;
        int updateCounter = 0;
        int lastFPS = 0;
        int fpsCounter = 0;
        // ---------------------

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = GameConstants.ScreenHeight;
            graphics.PreferredBackBufferWidth = GameConstants.ScreenWidth;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

            // Map
            map = new Map_2DTile();
            map.Load(Content, "./Content/Map1.txt");

            graphicsHandler.AddImage("player", Content.Load<Texture2D>("slime_medium"));
            graphicsHandler.AddImage("bomb", Content.Load<Texture2D>("bomb"));
            graphicsHandler.AddImage("explosion", Content.Load<Texture2D>("explosion"));

            objectSpawnController = new ObjectSpawnController(eventHandler, gameObjects, graphicsHandler, map);
            collisionHandler = new CollisionHandler(eventHandler, gameObjects);
            // How a spawn player event would be added, with the spawn code genereated inside ObjectSpawnController.
            eventHandler.QueueEvent(new SpawnEvent("player"));

            eventHandler.QueueEvent(new SpawnEvent("player2"));

            font = Content.Load<SpriteFont>("font");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            // Clears all old events, and puts all queued events into new event list.
            eventHandler.NewRound();

            objectSpawnController.Update(gameTime);
            collisionHandler.Update(gameTime);

            List<GameObject> gameObjectsToRemove = new List<GameObject>();
            // Updates all objects.
            for (int i = 0; i < gameObjects.Count; i++)
            {
                if (gameObjects[i].remove)
                    gameObjectsToRemove.Add(gameObjects[i]);
                gameObjects[i].Update(gameTime);
            }
            foreach (GameObject gO in gameObjectsToRemove)
            {
                gameObjects.Remove(gO);
            }


            // FPS counter just to check if anything affects performance.
            fpsTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (fpsTimer <= 0)
            {
                lastFPS = fpsCounter;
                lastUpdate = updateCounter;
                updateCounter = 0;
                fpsCounter = 0;
                fpsTimer = 1.0;
            }
            fpsCounter++;
            // ---------------------------------------------------------

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            map.Draw(spriteBatch);

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw(spriteBatch);
            }

            // FPS counter
            spriteBatch.DrawString(font, "Updates: " + lastFPS, Vector2.Zero, Color.Red);
            spriteBatch.DrawString(font, "FPS: " + lastUpdate, new Vector2(0, 50), Color.Red);
            // ----------
            spriteBatch.End();

            updateCounter++; // FPS Counter

            base.Draw(gameTime);
        }
    }
}
