using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MyGame
{
    public class Bomb
    {
        private Texture2D texture;
        private Rectangle sourceRect;
        public Rectangle boundingBox;
        private Vector2 direction;
        public Vector2 position;
        private float speed;

        public Bomb(Texture2D texture,Rectangle sourceRect, Vector2 startPosition, float bulletSpeed)
        {
            this.texture = texture;
            this.sourceRect = sourceRect;
            position = startPosition;
            speed = bulletSpeed;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, this.sourceRect.Width, this.sourceRect.Height);
        }

        public void Update(GameTime gameTime)
        {
            position += direction * speed;
            boundingBox.Location = position.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRect, Color.White);
        }

        public void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }
    }
}
