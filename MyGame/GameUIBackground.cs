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

            // Загрузка текстур
            backgroundTexture = Game1.Instance.Content.Load<Texture2D>("UI/background");

            //leftBarTexture = Game1.Instance.Content.Load<Texture2D>("UI/left_bar");
            //rightBarTexture = Game1.Instance.Content.Load<Texture2D>("UI/right_bar");
             // Создание прямоугольников для текстур
             backgroundRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            //leftBarRectangle = new Rectangle(0, 0, leftBarTexture.Width, screenHeight);
            //rightBarRectangle = new Rectangle(screenWidth - rightBarTexture.Width, 0, rightBarTexture.Width, screenHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Отрисовка фона
            spriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);

            // Отрисовка боковых элементов
            spriteBatch.Draw(leftBarTexture, leftBarRectangle, Color.White);
            spriteBatch.Draw(rightBarTexture, rightBarRectangle, Color.White);
        }
    }

}
