using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MyGame
{
    public class Bonus
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 direction;
        private Rectangle size;
        public Rectangle boundingBox;
        private float speed;
        public Bonuses.BonusType type;

        public Bonus(Texture2D texture, Vector2 position, Rectangle size)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
            direction = new Vector2(0, +1);
            speed = 8f;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, size.Width, size.Height);
        }

        public void Update(GameTime gameTime)
        {
            position += direction * speed;
            boundingBox.Location = position.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, size, Color.White);
        }
    }
}
