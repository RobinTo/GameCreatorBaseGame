using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ComponentGameTest
{
    class GraphicsHandler2D
    {
        Dictionary<string, Texture2D> images = new Dictionary<string, Texture2D>();

        public Texture2D getTexture(string identifier)
        {
            return images[identifier];
        }

        public void AddImage(string identifier, Texture2D image)
        {
            images.Add(identifier, image);
        }
    }
}
