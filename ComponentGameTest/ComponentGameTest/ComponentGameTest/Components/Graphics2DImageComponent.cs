// Title
// 2D Single Image

// Description
// Draws a single 2D image.

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ComponentGameTest
{
    class Graphics2DImageComponent : GraphicsComponent
    {
        public override void Draw(GameObject gameObject, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gameObject.texture, gameObject.position, gameObject.color);
        }
    }
}
