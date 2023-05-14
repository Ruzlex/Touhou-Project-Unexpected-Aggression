using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace MyGame
{
    public class HomingBullet
    {
        public Texture2D texture;
        private Vector2 position;
        public Vector2 direction;
        private Rectangle size;
        private float speed;
        public float rotationAngle;
        private Enemy enemy;

        public HomingBullet(Texture2D texture, Vector2 position, Rectangle size, float speed, Enemy enemy)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
            direction = new Vector2(0, -1);
            this.enemy = enemy;
            this.speed = speed;
            rotationAngle = 0f;
        }

        public void Update(GameTime gameTime)
        {
            position += direction * speed;
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
        
        public void FindWay(Vector2 direction, Enemy enemy)
        {
            Vector2 enemyPosition = enemy.position + new Vector2(20, 30);
            direction = enemyPosition - position;
            direction.Normalize();
        }
    }
}
