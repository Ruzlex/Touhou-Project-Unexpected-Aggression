using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemBullet
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 direction;
        private Rectangle size;
        private float speed;
        public float rotationAngle;
        public Rectangle boundingBox;
        public EnemBullet(Texture2D texture, Vector2 position, Rectangle size, float speed)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
            direction = new Vector2(0, -1);
            this.speed = speed;
            rotationAngle = 0f;
            boundingBox = new Rectangle((int)position.X - 12, (int)position.Y - 12, (int)(size.Width * 1.5), (int)(size.Height * 1.5));
        }

        public void Update(GameTime gameTime)
        {
            position += direction * speed;
            boundingBox.Location = position.ToPoint() - new Point(12, 12);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 origin = new Vector2(size.Width / 2, size.Height / 2);
            spriteBatch.Draw(texture, position, size, Color.White, rotationAngle, origin, 1.5f, SpriteEffects.None, 0f);
        }

        public void SetRotationAngle(float angle)
        {
            rotationAngle = angle;
        }

        public void SetDirection(Vector2 direction)
        {
            this.direction = direction;
        }
    }
}
