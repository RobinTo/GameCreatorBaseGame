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
        Texture2D texture = null;
        Color color = Color.White;

        public Graphics2DImageComponent(Texture2D texture)
        {
            this.texture = texture;
        }

        public override void Update(GameObject gameObject, GameTime gameTime)
        {
            gameObject.height = texture.Height;
            gameObject.width = texture.Width;
        }

        public override void Draw(GameObject gameObject, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(gameObject.xPosition, gameObject.yPosition), color);
        }
    }
}
