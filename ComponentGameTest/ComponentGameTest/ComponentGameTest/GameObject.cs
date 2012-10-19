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
        public float xPosition;
        public float yPosition;
        public float xVelocity;
        public float yVelocity;

        public Texture2D texture;
        public Vector2 position;
        public Rectangle sourceRectangle;
        public Color color;
        public float rotation;
        public Vector2 origin;
        public float scale;
        public SpriteEffects effects;
        public float layerDepth;

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
