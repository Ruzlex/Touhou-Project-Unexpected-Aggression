using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace MyGame
{
    public class Shooting
    {
        private Texture2D texture;
        public Vector2 position;
        private List<Bullet> bullets;
        private Rectangle size;
        public SoundEffect shoot;
        public PlayerReimu player;
        public Shooting(PlayerReimu player)
        {
            this.texture = Game1.Instance.Content.Load<Texture2D>("PlayerReimu");
            this.bullets = new List<Bullet>();
            this.size = new Rectangle(132, 3, 10, 13);
            shoot = Game1.Instance.Content.Load<SoundEffect>("Shooting");
            this.player = player;
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
            if (player.Power < 8)
            {
                Bullet bullet = new Bullet(texture, position, size);
                bullets.Add(bullet);
            }
            else if (player.Power >= 8)
            {
                Bullet bullet = new Bullet(texture, position, size);
                bullets.Add(bullet);

                Bullet bullet2 = new Bullet(texture, new Vector2(position.X + 15, position.Y), size);
                bullet2.direction = new Vector2(-0.01f, -1);
                bullets.Add(bullet2);
            }
        }
    }
}
