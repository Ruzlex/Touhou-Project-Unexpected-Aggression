using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame
{
    public class Bullet
    {
        private Texture2D texture;
        private Vector2 position;
        public Vector2 direction;
        private Rectangle size;
        private float speed;

        public Bullet(Texture2D texture, Vector2 position, Rectangle size)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
            direction = new Vector2(0, -1);
            speed = 8f;
        }

        public void Update(GameTime gameTime)
        {
            position += direction * speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, size, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
        }
    }
}
