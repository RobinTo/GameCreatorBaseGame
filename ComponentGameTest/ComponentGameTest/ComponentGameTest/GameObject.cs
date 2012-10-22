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
        public int ID;              // Unique ID

        public float xPosition = 0; // For position
        public float yPosition = 0; // For position
        public int height = 0;      // For collision
        public int width = 0;       // For collision

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

            foreach (GraphicsComponent drawComp in drawComponents)
                drawComp.Update(this, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (GraphicsComponent drawComp in drawComponents)
                drawComp.Draw(this, spriteBatch);
        }

    }
}
