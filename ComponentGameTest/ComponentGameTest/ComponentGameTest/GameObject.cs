// Title
// Basic Game Object

// Description
// Basic game object, just create objects with different components to create properties.

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ComponentGameTest
{
    class GameObject
    {
        public int ID;

        public float xPosition = 0;
        public float yPosition = 0;
        public float xVelocity = 0;
        public float yVelocity = 0;
        public float maxXVelocity = 5;
        public float maxYVelocity = 5;

        public Texture2D texture = null;
        public Vector2 position = Vector2.Zero;
        public Rectangle sourceRectangle = new Rectangle(0,0,0,0);
        public Color color = Color.White;
        public float rotation = 0;
        public Vector2 origin = Vector2.Zero;
        public float scale = 1; 
        public SpriteEffects effects = SpriteEffects.None;
        public float layerDepth = 1;

        List<UpdateComponent> updateComponents = new List<UpdateComponent>();
        List<GraphicsComponent> drawComponents = new List<GraphicsComponent>();

        public void AddUpdateComponent(UpdateComponent updateComponent)
        {
            updateComponents.Add(updateComponent);
        }

        public void AddDrawComponent(GraphicsComponent drawComponent)
        {
            drawComponents.Add(drawComponent);
        }

        public GameObject()
        {

        }

        public GameObject(List<UpdateComponent> updateComponents)
        {
            this.updateComponents = updateComponents;
        }

        public GameObject(List<GraphicsComponent> drawComponents)
        {
            this.drawComponents = drawComponents;
        }

        public GameObject(List<UpdateComponent> updateComponents, List<GraphicsComponent> drawComponents)
        {
            this.updateComponents = updateComponents;
            this.drawComponents = drawComponents;
        }

        public void Update(GameTime gameTime)
        {
            position = new Vector2(xPosition, yPosition);

            foreach (UpdateComponent updateComp in updateComponents)
                updateComp.Update(this, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GraphicsComponent drawComp in drawComponents)
                drawComp.Draw(this, spriteBatch);
        }

    }
}
