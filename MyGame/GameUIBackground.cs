using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame
{
    public class GameUIBackground
    {
        private Texture2D HUD;
        private Texture2D backgroundTexture;
        private Texture2D leftBarTexture;
        private Texture2D rightBarTexture;
        private Rectangle leftBarRectangle;
        private Rectangle rightBarRectangle;
        private Rectangle backgroundRectangle;

        public GameUIBackground(GraphicsDevice graphicsDevice)
        {
            int screenWidth = graphicsDevice.Viewport.Width;
            int screenHeight = graphicsDevice.Viewport.Height;


            backgroundTexture = Game1.Instance.Content.Load<Texture2D>("UI/background");


             backgroundRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);


            spriteBatch.Draw(leftBarTexture, leftBarRectangle, Color.White);
            spriteBatch.Draw(rightBarTexture, rightBarRectangle, Color.White);
        }
    }

}
