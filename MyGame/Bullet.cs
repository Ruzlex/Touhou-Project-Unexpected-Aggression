﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame
{
    public class Bullet
    {
        public Texture2D texture;
        private Vector2 position;
        public Vector2 direction;
        private Rectangle size;
        private float speed;
        public float rotationAngle;
        public Rectangle boundingBox;
        public Bullet(Texture2D texture, Vector2 position, Rectangle size, float speed)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
            direction = new Vector2(0, -1);
            this.speed = speed;
            rotationAngle = 0f;
            boundingBox = new Rectangle((int)position.X, (int)position.Y, size.Width, size.Height);
        }

        public void Update(GameTime gameTime)
        {
            position += direction * speed;
            boundingBox.Location = position.ToPoint();
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
    }
}
