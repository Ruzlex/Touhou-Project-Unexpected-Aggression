using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MyGame
{
    public class Shooting
    {
        private Texture2D texture;
        public Vector2 position;
        private List<Bullet> bullets;
        private Rectangle size;

        public Shooting()
        {
            this.texture = Game1.Instance.Content.Load<Texture2D>("PlayerReimu");
            this.bullets = new List<Bullet>();
            this.size = new Rectangle(132, 3, 10, 13);
        }

        public void Update(GameTime gameTime)
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gameTime);
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Bullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }    
        }

        public void Shoot(Vector2 position)
        {

            Bullet bullet = new Bullet(texture, position, size);
            bullets.Add(bullet);
        }
    }
}
